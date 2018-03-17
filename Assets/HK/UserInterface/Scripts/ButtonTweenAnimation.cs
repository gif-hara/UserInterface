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
    [RequireComponent(typeof(TweenTarget))]
    public class ButtonTweenAnimation :
        MonoBehaviour,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField]
        private SequenceObject pointerDown;

        [SerializeField]
        private SequenceObject pointerUp;

        [SerializeField]
        private bool onPointerTakeOffTween;

        private TweenTarget target;
        
        private Sequence currentSequence;

        private bool pressed;

        public SequenceObject PointerDown { get { return pointerDown; } set { pointerDown = value; } }

        public SequenceObject PointerUp { get { return pointerUp; } set { pointerUp = value; } }

        public bool OnPointerTakeOffTween { get { return onPointerTakeOffTween; } set { onPointerTakeOffTween = value; } }

        void Awake()
        {
            Assert.IsNotNull(this.pointerDown);
            Assert.IsNotNull(this.pointerUp);

            this.target = this.GetComponent<TweenTarget>();
            Assert.IsNotNull(this.target);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            this.InvokeSequence(this.pointerDown.Invoke(this.target));
            this.pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.InvokeSequence(this.pointerUp.Invoke(this.target));
            this.pressed = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
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
