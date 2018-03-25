using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface
{
    /// <summary>
    /// 
    /// </summary>
    [ExecuteInEditMode]
    public sealed class PanelScaler : MonoBehaviour
    {
        [SerializeField]
        private RectTransform parent;
        
        private RectTransform cachedTransform;
        
        #if UNITY_EDITOR
        void Update()
        {
            if (this.cachedTransform == null)
            {
                this.cachedTransform = this.transform as RectTransform;
            }
            if (this.parent == null)
            {
                this.parent = this.cachedTransform.parent as RectTransform;
            }
            
            var width = this.parent.rect.width;
            var height = this.parent.rect.height;
            if (width < height)
            {
                Debug.Log(string.Format("Width = {0} Height = {1}", Screen.width, Screen.height));
                var rate = 1.0f - ((float)width / height);
                var halfRate = rate * 0.5f;
                var anchorMin = this.cachedTransform.anchorMin;
                anchorMin.y = halfRate;
                this.cachedTransform.anchorMin = anchorMin;

                var anchorMax = this.cachedTransform.anchorMax;
                anchorMax.y = 1.0f - halfRate;
                this.cachedTransform.anchorMax = anchorMax;
            }
        }
        #endif
    }
}
