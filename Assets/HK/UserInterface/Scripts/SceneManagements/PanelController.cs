using HK.UserInterface.SceneManagements;
using UniRx;
using UnityEngine;

namespace HK.UserInterface.SceneManagements
{
    /// <summary>
    /// パネルを制御するクラス
    /// </summary>
    public abstract class PanelController : MonoBehaviour, IPanel
    {
        public abstract IObservable<Unit> OnPanelIn();

        public abstract IObservable<Unit> OnPanelOut();
    }
}
