using DG.Tweening;
using UniRx;

namespace HK.UserInterface
{
    /// <summary>
    /// <see cref="DOTween"/>の拡張クラス
    /// </summary>
    public static partial class Extensions
    {
        public static IObservable<Unit> OnCompleteAsObservable(this Tween self)
        {
            var observer = new Subject<Unit>();
            self.OnComplete(() =>
            {
                observer.OnNext(Unit.Default);
                observer.OnCompleted();
            });

            return observer;
        }
    }
}
