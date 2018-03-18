using System.Collections.Generic;
using HK.Framework.EventSystems;
using HK.UserInterface.Events.SceneManagements;
using UniRx;
using UniRx.Triggers;
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

        public IObservable<Unit> OnPanelIn()
        {
            return this.InternalOnPanelIn();
        }

        public IObservable<Unit> OnPanelOut()
        {
            UniRxEvent.GlobalBroker.Publish(ClosePanel.Get(this));
            return this.InternalOnPanelOut();
        }

        protected abstract IObservable<Unit> InternalOnPanelIn();
        
        protected abstract IObservable<Unit> InternalOnPanelOut();
    }
}
