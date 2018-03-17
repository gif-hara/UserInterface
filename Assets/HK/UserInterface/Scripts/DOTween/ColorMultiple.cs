using DG.Tweening;
using UnityEngine;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// 乗算カラーアニメーションを行う
    /// </summary>
    [CreateAssetMenu(menuName = "HK/UserInterface/Animations/Tween/ColorMultiple")]
    public sealed class ColorMultiple : TweenObject
    {
        [SerializeField]
        private Color to;

        [SerializeField]
        private float multiple = 1.0f;
        
        public override Tween Tween(TweenTarget target)
        {
            var multipleTo = target.DefaultColor * (this.to * this.multiple);
            return target.Graphic.DOColor(multipleTo, this.duration).SetEase(this.ease);
        }

        #if UNITY_EDITOR
        protected override string AssetName { get { return string.Format("{0}_{1}_{2}", base.AssetName, this.to, this.multiple); } }
        #endif
    }
}
