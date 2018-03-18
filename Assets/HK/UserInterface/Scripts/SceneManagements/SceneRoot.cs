using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface.SceneManagements
{
    /// <summary>
    /// シーンのルートを制御するクラス
    /// </summary>
    public sealed class SceneRoot : PanelController
    {
        private static SceneRoot instance;
        
        public static SceneRoot Instance { get { return instance; } }
        
        [SerializeField]
        private Transform panelParent;
        
        [SerializeField]
        private PanelController initialPanel;

        [SerializeField]
        private float startDelay;

        private PanelController root;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(this.startDelay))
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.OnPanelIn();
                })
                .AddTo(this);
        }

        void OnDestroy()
        {
            instance = null;
        }

        public void Change(PanelController prefab)
        {
            if (this.root != null)
            {
                this.root.OnPanelOut()
                    .Take(1)
                    .SubscribeWithState2(this, prefab, (_, _this, p) =>
                    {
                        Destroy(_this.root.gameObject);
                        _this.root = _this.CreatePanel(p);
                        _this.root.OnPanelIn();
                    })
                    .AddTo(this);
            }
            else
            {
                this.root = this.CreatePanel(prefab);
                this.root.OnPanelIn();
            }
        }

        private PanelController CreatePanel(PanelController prefab)
        {
            var panel = Instantiate(prefab);
            panel.transform.SetParent(this.panelParent, false);
            return panel;
        }

        protected override UniRx.IObservable<Unit> InternalOnPanelIn()
        {
            this.root = this.CreatePanel(this.initialPanel);
            return this.root.OnPanelIn();
        }

        protected override UniRx.IObservable<Unit> InternalOnPanelOut()
        {
            throw new NotImplementedException();
        }
    }
}
