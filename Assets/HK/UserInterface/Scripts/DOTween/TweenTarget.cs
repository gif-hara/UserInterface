using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// アニメーションするオブジェクトを制御するクラス
    /// </summary>
    public sealed class TweenTarget : MonoBehaviour
    {
        [SerializeField]
        private Graphic graphic;

        private Color defaultColor;

        public Graphic Graphic { get { return graphic; } set { graphic = value; } }

        void Awake()
        {
            if (this.graphic == null)
            {
                this.graphic = this.GetComponent<Graphic>();
            }
            
            Assert.IsNotNull(this.graphic);
            this.defaultColor = this.graphic.color;
            Debug.Log(this.defaultColor);
        }
        
        #if UNITY_EDITOR
        void Reset()
        {
            this.graphic = this.GetComponent<Graphic>();
        }
        #endif
    }
}
