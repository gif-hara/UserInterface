using DG.Tweening;
using UnityEngine;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// スケールアニメーションを行う
    /// </summary>
    public sealed class Scale : TweenObject
    {
        [SerializeField]
        private Vector3 to;
        
        public override Tween Tween(GameObject gameObject)
        {
            return gameObject.transform.DOScale(this.to, this.duration).SetEase(this.ease);
        }
    }
}
