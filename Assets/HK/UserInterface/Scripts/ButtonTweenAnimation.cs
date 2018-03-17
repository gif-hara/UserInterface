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
        private GameObject target;
        
        [SerializeField]
        private SequenceObject pointerDown;

        [SerializeField]
        private SequenceObject pointerUp;

        [SerializeField]
        private bool onPointerTakeOffTween;

        private Sequence currentSequence;

        private bool pressed;

        public GameObject Target { get { return target; } set { target = value; } }

        public SequenceObject PointerDown { get { return pointerDown; } set { pointerDown = value; } }

        public SequenceObject PointerUp { get { return pointerUp; } set { pointerUp = value; } }

        public bool OnPointerTakeOffTween { get { return onPointerTakeOffTween; } set { onPointerTakeOffTween = value; } }

        void Awake()
        {
            Assert.IsNotNull(this.pointerDown);
            Assert.IsNotNull(this.pointerUp);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            this.InvokeSequence(this.pointerDown.Invoke(this.target));
            this.pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.pressed = false;
            if (!this.onPointerTakeOffTween)
            {
                this.InvokeSequence(this.pointerUp.Invoke(this.target));
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            this.InvokeSequence(this.pointerUp.Invoke(this.target));
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
