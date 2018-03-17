using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface.SceneManagements
{
    /// <summary>
    /// シーンのルートを制御するクラス
    /// </summary>
    public sealed class SceneRoot : MonoBehaviour
    {
        [SerializeField]
        private Transform panelParent;
        
        [SerializeField]
        private PanelController initialPanel;

        [SerializeField]
        private float startDelay;

        void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(this.startDelay))
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.CreatePanel(_this.initialPanel).OnPanelIn();
                })
                .AddTo(this);
        }

        private PanelController CreatePanel(PanelController prefab)
        {
            var panel = Instantiate(prefab);
            panel.transform.SetParent(this.panelParent, false);
            return panel;
        }
    }
}
