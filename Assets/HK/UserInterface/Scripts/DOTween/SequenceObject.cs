using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// シーケンスを行える<see cref="ScriptableObject"/>
    /// </summary>
    [CreateAssetMenu(menuName = "HK/UserInterface/Animations/Sequence")]
    public class SequenceObject : ScriptableObject
    {
        [SerializeField]
        private Element[] elements;

        public Sequence Invoke(GameObject gameObject)
        {
            var result = DOTween.Sequence();
            foreach (var element in this.elements)
            {
                element.Attach(result, gameObject);
            }
            return result;
        }
        
        public enum SequenceType
        {
            Append,
            Join,
        }
        
        [Serializable]
        public class Element
        {
            [SerializeField]
            private TweenObject tween;

            [SerializeField]
            private SequenceType type;

            public Sequence Attach(Sequence sequence, GameObject gameObject)
            {
                switch (this.type)
                {
                    case SequenceType.Append:
                        return sequence.Append(this.tween.Tween(gameObject));
                    case SequenceType.Join:
                        return sequence.Join(this.tween.Tween(gameObject));
                    default:
                        Assert.IsTrue(false, string.Format("未対応の値です {0}", this.type));
                        return null;
                }
            }
        }
    }
}
