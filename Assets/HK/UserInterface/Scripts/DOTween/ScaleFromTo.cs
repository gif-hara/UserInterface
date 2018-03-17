using DG.Tweening;
using UnityEngine;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// スケールアニメーションを行う
    /// </summary>
    [CreateAssetMenu(menuName = "HK/UserInterface/Animations/Tween/ScaleFromTo")]
    public sealed class ScaleFromTo : TweenObject
    {
        [SerializeField]
        private Vector3 from;
        
        [SerializeField]
        private Vector3 to;
        
        public override Tween Tween(TweenTarget target)
        {
            target.Graphic.transform.localScale = this.from;
            return target.Graphic.transform.DOScale(this.to, this.duration).SetEase(this.ease);
        }

        #if UNITY_EDITOR
        protected override string AssetName { get { return string.Format("{0}_{1}_{2}", base.AssetName, this.from, this.to); } }
        #endif
    }
}
