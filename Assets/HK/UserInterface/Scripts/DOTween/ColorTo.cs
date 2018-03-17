using DG.Tweening;
using UnityEngine;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// スケールアニメーションを行う
    /// </summary>
    [CreateAssetMenu(menuName = "HK/UserInterface/Animations/Tween/ColorTo")]
    public sealed class ColorTo : TweenObject
    {
        [SerializeField]
        private Color to;
        
        public override Tween Tween(TweenTarget target)
        {
            return target.Graphic.DOColor(this.to, this.duration).SetEase(this.ease);
        }

        #if UNITY_EDITOR
        protected override string AssetName { get { return string.Format("{0}_{1}", base.AssetName, this.to); } }
        #endif
    }
}
