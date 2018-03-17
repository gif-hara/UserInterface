using UniRx;

namespace HK.UserInterface.SceneManagements
{
    /// <summary>
    /// パネル基底クラス
    /// </summary>
    public interface IPanel
    {
        /// <summary>
        /// パネルが開始する際のイベント
        /// </summary>
        IObservable<Unit> OnPanelIn();

        /// <summary>
        /// パネルが終了する際のイベント
        /// </summary>
        /// <returns></returns>
        IObservable<Unit> OnPanelOut();
    }
}
