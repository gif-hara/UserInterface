using System;
using DG.Tweening;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

        #if UNITY_EDITOR
        private void OnValidate()
        {
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), this.AssetName);
        }

        /// <summary>
        /// アセットの名前を返す
        /// </summary>
        /// <remarks>
        /// <c>typename</c>_<c>duration</c>_<c>ease</c>_xxx
        /// </remarks>
        protected virtual string AssetName
        {
            get { return string.Format("{0}_{1}", this.duration, this.ease); }
        }
        #endif
    }
}
