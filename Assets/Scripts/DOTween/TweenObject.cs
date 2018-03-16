using DG.Tweening;
using UnityEngine;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// ツイーンを行える<see cref="ScriptableObject"/>の抽象クラス
    /// </summary>
    public abstract class TweenObject : ScriptableObject
    {
        [SerializeField]
        protected float duration;

        [SerializeField]
        protected Ease ease;
        
        public abstract Tween Tween(GameObject gameObject);
    }
}
