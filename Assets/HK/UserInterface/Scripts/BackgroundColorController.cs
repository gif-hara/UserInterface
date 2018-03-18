using HK.Framework.EventSystems;
using HK.UserInterface.Enums;
using HK.UserInterface.Events.GameSystems;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface.GameSystems
{
    /// <summary>
    /// 背景色を制御するクラス
    /// </summary>
    public sealed class BackgroundColorController : MonoBehaviour
    {
        [SerializeField]
        private Camera controlledCamera;

        void Awake()
        {
            UniRxEvent.GlobalBroker.Receive<ChangeBackgroundColor>()
                .SubscribeWithState(this, (x, _this) => _this.Change(x.ColorType))
                .AddTo(this);
        }

        private void Change(ColorType colorType)
        {
            this.controlledCamera.backgroundColor = colorType.ToColor();
        }
    }
}
