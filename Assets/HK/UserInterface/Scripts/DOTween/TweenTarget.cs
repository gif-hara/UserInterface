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
        private Graphic target;

        private Color defaultColor;

        public Graphic Target { get { return target; } set { target = value; } }

        void Awake()
        {
            if (this.target == null)
            {
                this.target = this.GetComponent<Graphic>();
            }
            
            Assert.IsNotNull(this.target);
            this.defaultColor = this.target.color;
            Debug.Log(this.defaultColor);
        }
        
        #if UNITY_EDITOR
        void Reset()
        {
            this.target = this.GetComponent<Graphic>();
        }
        #endif
    }
}
