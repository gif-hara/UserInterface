using HK.Framework.EventSystems;
using HK.UserInterface.SceneManagements;

namespace HK.UserInterface.Events.SceneManagements
{
    /// <summary>
    /// パネルが閉じられる際のイベント
    /// </summary>
    public sealed class ClosePanel : UniRxEvent<ClosePanel, PanelController>
    {
        /// <summary>
        /// 閉じられるパネル
        /// </summary>
        public PanelController PanelController { get { return this.param1; } }
    }
}
