using DG.Tweening;
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
        private static BackgroundColorController instance;
        
        public static BackgroundColorController Instance { get { return instance; } }
        
        [SerializeField]
        private Camera controlledCamera;

        [SerializeField]
        private float duration;

        [SerializeField]
        private Ease ease;

        [SerializeField]
        private ColorType initialColorType;

        private Tweener changeColor;

        public ColorType CurrentColorType { get; private set; }

        void Awake()
        {
            instance = this;
            
            Assert.IsNotNull(this.controlledCamera);
            UniRxEvent.GlobalBroker.Receive<ChangeBackgroundColor>()
                .SubscribeWithState(this, (x, _this) => _this.Change(x.ColorType))
                .AddTo(this);
        }

        void OnDestroy()
        {
            instance = null;
        }
        
        #if UNITY_EDITOR
        void OnValidate()
        {
            if (this.controlledCamera != null)
            {
                this.controlledCamera.backgroundColor = this.initialColorType.ToColor();
            }
        }
        #endif

        private void Change(ColorType colorType)
        {
            if (this.changeColor != null)
            {
                this.changeColor.Kill();
            }
            
            this.changeColor = this.controlledCamera.DOColor(colorType.ToColor(), this.duration).SetEase(this.ease);
            this.CurrentColorType = colorType;
        }
    }
}
