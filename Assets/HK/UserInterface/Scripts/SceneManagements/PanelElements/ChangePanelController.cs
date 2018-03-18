using HK.UserInterface.SceneManagements;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.UserInterface.PanelElements
{
    /// <summary>
    /// <see cref="PanelController"/>を切り替えるクラス
    /// </summary>
    public sealed class ChangePanelController : PanelElement
    {
        [SerializeField]
        private Selectable selectable;

        [SerializeField]
        private PanelController panelController;

        protected override void Awake()
        {
            base.Awake();
            this.selectable.OnPointerClickAsObservable()
                .Where(_ => this.selectable.interactable)
                .SubscribeWithState(this, (_, _this) =>
                {
                    SceneRoot.Instance.Change(_this.panelController);
                })
                .AddTo(this);
        }
    }
}
