using System;
using System.Linq;
using DG.Tweening;
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
            private Elements[] elements;

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
        public class Elements
        {
            [SerializeField]
            private Element[] elements;

            public void Setup()
            {
                foreach (var element in this.elements)
                {
                    element.Setup();
                }
            }
            
            public UniRx.IObservable<Unit> InvokeIn(GameObject owner, float delay)
            {
                return Observable.Zip(this.elements.Select(e => e.InvokeIn(owner, delay))).AsUnitObservable();
            }
            
            public UniRx.IObservable<Unit> InvokeOut(GameObject owner, float delay)
            {
                return Observable.Zip(this.elements.Select(e => e.InvokeOut(owner, delay))).AsUnitObservable();
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
                return this.CreateTimer(this.inSequence, owner, delay);
            }

            public UniRx.IObservable<Unit> InvokeOut(GameObject owner, float delay)
            {
                return this.CreateTimer(this.outSequence, owner, delay);
            }

            private UniRx.IObservable<Unit> CreateTimer(SequenceObject sequenceObject, GameObject owner, float delay)
            {
                var sequence = sequenceObject.Invoke(this.target).Pause();
                var observer = Observable.Timer(TimeSpan.FromSeconds(delay)).Share();
                observer.SubscribeWithState2(this, sequence, (_, _this, s) =>
                    {
                        s.Play();
                    })
                    .AddTo(owner);

                return sequence.OnCompleteAsObservable();
            }
        }
    }
}
