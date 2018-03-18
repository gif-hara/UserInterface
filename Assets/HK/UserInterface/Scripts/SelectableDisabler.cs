using HK.Framework.EventSystems;
using HK.UserInterface.Events.SceneManagements;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace HK.UserInterface.PanelElements
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SelectableDisabler : PanelElement
    {
        [SerializeField]
        private Selectable selectable;

        protected override void Awake()
        {
            base.Awake();
            UniRxEvent.GlobalBroker.Receive<ClosePanel>()
                .Where(x => x.PanelController == this.owner)
                .SubscribeWithState(this, (_, _this) => _this.selectable.interactable = false)
                .AddTo(this);
        }

        #if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            this.selectable = this.GetComponent<Selectable>();
            if (this.selectable == null)
            {
                Debug.LogError("Selectableコンポーネントが存在しません");
                DestroyImmediate(this);
            }
        }
        #endif
    }
}
