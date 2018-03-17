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

        public Graphic Graphic
        {
            get
            {
                return this.graphic;
            }
            set
            {
                this.graphic = value;
                Assert.IsNotNull(this.graphic);
                this.defaultColor = this.graphic.color;
            }
        }

        public Color DefaultColor { get { return defaultColor; } }

        void Awake()
        {
            if (this.graphic == null)
            {
                this.graphic = this.GetComponent<Graphic>();
            }
            
            Assert.IsNotNull(this.graphic);
            this.defaultColor = this.graphic.color;
        }
        
        #if UNITY_EDITOR
        void Reset()
        {
            this.graphic = this.GetComponent<Graphic>();
        }
        #endif
    }
}
