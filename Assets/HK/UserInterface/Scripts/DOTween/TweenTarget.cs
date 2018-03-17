using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// アニメーションするオブジェクトを制御するクラス
    /// </summary>
    [Serializable]
    public sealed class TweenTarget
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

        public void Setup()
        {
            Assert.IsNotNull(this.graphic);
            this.defaultColor = this.graphic.color;
        }
    }
}
