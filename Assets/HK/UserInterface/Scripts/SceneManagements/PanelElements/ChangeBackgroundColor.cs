using HK.Framework.EventSystems;
using HK.UserInterface.Enums;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.UserInterface.PanelElements
{
    /// <summary>
    /// 背景色を変える<see cref="PanelElement"/>
    /// </summary>
    public sealed class ChangeBackgroundColor : PanelElement
    {
        [SerializeField]
        private Selectable selectable;

        [SerializeField]
        private ColorType colorType;

        public ColorType ColorType { get { return colorType; } set { colorType = value; } }

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(this.selectable);
            this.selectable.OnPointerClickAsObservable()
                .Where(_ => this.selectable.interactable)
                .SubscribeWithState(this, (_, _this) =>
                {
                    UniRxEvent.GlobalBroker.Publish(Events.GameSystems.ChangeBackgroundColor.GetCache(_this.colorType));
                })
                .AddTo(this);
        }
        
        #if UNITY_EDITOR
        void Reset()
        {
            this.selectable = this.GetComponent<Selectable>();
        }
        #endif
    }
}
