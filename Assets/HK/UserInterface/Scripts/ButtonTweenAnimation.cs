using DG.Tweening;
using HK.UserInterface.Animations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace HK.UserInterface
{
    /// <summary>
    /// ボタンのアニメーションを<see cref="DOTween"/>で行うクラス
    /// </summary>
    public class ButtonTweenAnimation :
        MonoBehaviour,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerClickHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField]
        private SequenceObject pointerDown;

        [SerializeField]
        private SequenceObject pointerUp;

        private GameObject cachedGameObject;

        private Sequence currentSequence;

        private bool pressed;

        void Awake()
        {
            Assert.IsNotNull(this.pointerDown);
            Assert.IsNotNull(this.pointerUp);
            this.cachedGameObject = this.gameObject;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            this.InvokeSequence(this.pointerDown.Invoke(this.cachedGameObject));
            this.pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.pressed = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            this.InvokeSequence(this.pointerUp.Invoke(this.cachedGameObject));
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (this.pressed)
            {
                this.InvokeSequence(this.pointerDown.Invoke(this.cachedGameObject));
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.InvokeSequence(this.pointerUp.Invoke(this.cachedGameObject));
        }

        private void InvokeSequence(Sequence sequence)
        {
            if (this.currentSequence != null)
            {
                this.currentSequence.Kill();
            }

            this.currentSequence = sequence;
        }
    }
}
