﻿using System;
using HK.UserInterface.Animations;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface.SceneManagements
{
    /// <summary>
    /// ツイーンアニメーションするパネルを制御するクラス
    /// </summary>
    /// <remarks>
    /// 子要素を順番に表示非表示するだけ
    /// </remarks>
    public sealed class TweenPanelController : PanelController
    {
        [SerializeField]
        private ElementBundle elementBundle;

        void Awake()
        {
            this.elementBundle.Setup();
        }
        
        public override UniRx.IObservable<Unit> OnPanelIn()
        {
            return this.elementBundle.InvokeIn(this.gameObject);
        }

        public override UniRx.IObservable<Unit> OnPanelOut()
        {
            return this.elementBundle.InvokeOut(this.gameObject);
        }

        [Serializable]
        public class ElementBundle
        {
            [SerializeField]
            private Element[] elements;

            [SerializeField]
            private float tweenInterval;

            public void Setup()
            {
                foreach (var element in this.elements)
                {
                    element.Setup();
                }
            }

            public UniRx.IObservable<Unit> InvokeIn(GameObject owner)
            {
                var observers = new UniRx.IObservable<Unit>[this.elements.Length];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    observers[i] = this.elements[i].InvokeIn(owner, this.tweenInterval * i);
                }

                return Observable.Zip(observers).AsUnitObservable();
            }
            
            public UniRx.IObservable<Unit> InvokeOut(GameObject owner)
            {
                var observers = new UniRx.IObservable<Unit>[this.elements.Length];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    observers[i] = this.elements[i].InvokeOut(owner, this.tweenInterval * i);
                }

                return Observable.Zip(observers).AsUnitObservable();
            }
        }
        [Serializable]
        public class Element
        {
            [SerializeField]
            private TweenTarget target;

            [SerializeField]
            private SequenceObject inSequence;

            [SerializeField]
            private SequenceObject outSequence;

            public void Setup()
            {
                this.target.Setup();
            }

            public UniRx.IObservable<Unit> InvokeIn(GameObject owner, float delay)
            {
                return this.CreateTimer(this.inSequence, owner, delay).AsUnitObservable();
            }

            public UniRx.IObservable<Unit> InvokeOut(GameObject owner, float delay)
            {
                return this.CreateTimer(this.outSequence, owner, delay).AsUnitObservable();
            }

            private UniRx.IObservable<long> CreateTimer(SequenceObject sequence, GameObject owner, float delay)
            {
                var observer = Observable.Timer(TimeSpan.FromSeconds(delay)).Share();
                observer.SubscribeWithState2(this, sequence, (_, _this, s) =>
                    {
                        s.Invoke(_this.target);
                    })
                    .AddTo(owner);

                return observer;
            }
        }
    }
}