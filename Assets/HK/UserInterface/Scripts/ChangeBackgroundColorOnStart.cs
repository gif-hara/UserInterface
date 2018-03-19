using HK.Framework.EventSystems;
using HK.UserInterface.Enums;
using HK.UserInterface.Events.GameSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface.GameSystems
{
    /// <summary>
    /// <see cref="Start"/>のタイミングで背景色を切り替える
    /// </summary>
    public sealed class ChangeBackgroundColorOnStart : MonoBehaviour
    {
        [SerializeField]
        private ColorType colorType;

        public ColorType ColorType { get { return colorType; } set { colorType = value; } }
        
        void Start()
        {
            UniRxEvent.GlobalBroker.Publish(ChangeBackgroundColor.GetCache(this.colorType));
        }
    }
}
