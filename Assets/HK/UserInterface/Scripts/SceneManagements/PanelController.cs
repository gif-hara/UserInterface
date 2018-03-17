using System.Collections.Generic;
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
        protected PanelController parent;

        protected List<PanelController> children = new List<PanelController>();

        public void SetParent(PanelController parent)
        {
            if (this.parent != null)
            {
                this.parent.children.Remove(this);
            }

            this.parent = parent;
            
            if (this.parent != null)
            {
                this.parent.children.Add(this);
            }
        }
        
        public abstract IObservable<Unit> OnPanelIn();

        public abstract IObservable<Unit> OnPanelOut();
    }
}
