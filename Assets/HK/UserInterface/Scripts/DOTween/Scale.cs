using DG.Tweening;
using UnityEngine;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// スケールアニメーションを行う
    /// </summary>
    [CreateAssetMenu(menuName = "HK/UserInterface/Animations/Tween/Scale")]
    public sealed class Scale : TweenObject
    {
        [SerializeField]
        private Vector3 to;
        
        public override Tween Tween(TweenTarget target)
        {
            return target.Graphic.transform.DOScale(this.to, this.duration).SetEase(this.ease);
        }

        #if UNITY_EDITOR
        protected override string AssetName { get { return string.Format("Scale_{0}_{1}", base.AssetName, this.to); } }
        #endif
    }
}
