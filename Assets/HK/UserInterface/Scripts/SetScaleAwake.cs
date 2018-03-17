using UnityEngine;

namespace HK.UserInterface.Animations
{
    /// <summary>
    /// <see cref="Awake"/>のタイミングでスケールを設定するクラス
    /// </summary>
    public sealed class SetScaleAwake : MonoBehaviour
    {
        [SerializeField]
        private Vector3 scale;
        
        void Awake()
        {
            this.transform.localScale = scale;
        }
    }
}
