using HK.UserInterface.SceneManagements;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface.PanelElements
{
    /// <summary>
    /// パネル内の実際に触れる要素を制御するクラス
    /// </summary>
    public abstract class PanelElement : MonoBehaviour
    {
        [SerializeField]
        protected PanelController owner;

        protected virtual void Awake()
        {
            Assert.IsNotNull(this.owner);
        }

        #if UNITY_EDITOR
        protected virtual void Reset()
        {
            this.owner = this.GetComponentInParent<PanelController>();
            if (this.owner == null)
            {
                Debug.LogError("OwnerとなるPanelControllerがありません");
                DestroyImmediate(this);
            }
        }
        #endif
    }
}
