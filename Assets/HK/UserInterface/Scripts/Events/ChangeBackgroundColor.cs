using HK.Framework.EventSystems;
using HK.UserInterface.Enums;

namespace HK.UserInterface.Events.GameSystems
{
    /// <summary>
    /// 背景色を変えるイベント
    /// </summary>
    public sealed class ChangeBackgroundColor : UniRxEvent<ChangeBackgroundColor, ColorType>
    {
        public ColorType ColorType { get { return this.param1; } }
    }
}
