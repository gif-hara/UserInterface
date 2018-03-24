using HK.UserInterface.Enums;
using HK.UserInterface.GameSystems;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.UserInterface
{
    /// <summary>
    /// 現状の背景色から操作可能か判断する
    /// </summary>
    public sealed class SetInteractableBackgroundColor : MonoBehaviour
    {
        [SerializeField]
        private Selectable selectable;

        [SerializeField]
        private ColorType negativeColorType;

        void Start()
        {
            this.selectable.interactable = BackgroundColorController.Instance.CurrentColorType != this.negativeColorType;
        }
        
        #if UNITY_EDITOR
        void Reset()
        {
            this.selectable = this.GetComponent<Selectable>();
        }
        #endif
    }
}
