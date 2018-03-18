using DG.Tweening;
using HK.UserInterface.Animations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HK.UserInterface
{
    /// <summary>
    /// ボタンのアニメーションを<see cref="DOTween"/>で行うクラス
    /// </summary>
    public class ButtonTweenAnimation :
        MonoBehaviour,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField]
        private Selectable selectable;
        
        [SerializeField]
        private TweenTarget target;
        
        [SerializeField]
        private SequenceObject pointerDown;

        [SerializeField]
        private SequenceObject pointerUp;

        [SerializeField]
        private bool onPointerTakeOffTween;

        private Sequence currentSequence;

        private bool pressed;

        public SequenceObject PointerDown { get { return pointerDown; } set { pointerDown = value; } }

        public SequenceObject PointerUp { get { return pointerUp; } set { pointerUp = value; } }

        public bool OnPointerTakeOffTween { get { return onPointerTakeOffTween; } set { onPointerTakeOffTween = value; } }

        void Awake()
        {
            Assert.IsNotNull(this.pointerDown);
            Assert.IsNotNull(this.pointerUp);

            this.target.Setup();
        }

        void OnValidate()
        {
            this.selectable = this.GetComponent<Selectable>();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!this.selectable.interactable)
            {
                return;
            }
            this.InvokeSequence(this.pointerDown.Invoke(this.target));
            this.pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!this.selectable.interactable)
            {
                return;
            }
            this.InvokeSequence(this.pointerUp.Invoke(this.target));
            this.pressed = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!this.selectable.interactable)
            {
                return;
            }
            if (!this.onPointerTakeOffTween)
            {
                return;
            }
            if (this.pressed)
            {
                this.InvokeSequence(this.pointerDown.Invoke(this.target));
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!this.selectable.interactable)
            {
                return;
            }
            if (!this.onPointerTakeOffTween)
            {
                return;
            }
            this.InvokeSequence(this.pointerUp.Invoke(this.target));
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
