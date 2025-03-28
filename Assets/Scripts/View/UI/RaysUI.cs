using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class RaysUI : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private bool clockwise = true;
        
        [SerializeField] [Range(0, 1)] private float fadeMinAlpha = 0.75f;
        [SerializeField] private float fadeDuration = 1f;
        
        [SerializeField] private Image _image;
        [SerializeField] private RectTransform _rectTransform;

        private Vector2 _centerPosition;
        private float _angle;
        private Tween _fadeTween;
        private Tween _rotationTween;

        private void Awake()
        {
            if (_image == null)
                _image = GetComponent<Image>();
            
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            StartFadeAnimation();
            StartRotationAnimation();
        }

        private void StartRotationAnimation()
        {
            float direction = clockwise ? -1f : 1f;
            
            _rotationTween = _rectTransform.DORotate(
                    new Vector3(0, 0, 360 * direction),
                    rotationSpeed > 0 ? 360f / rotationSpeed : 1f,
                    RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }

        private void StartFadeAnimation()
        {
            _fadeTween?.Kill();
            
            _fadeTween = _image.DOFade(fadeMinAlpha, fadeDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }

        private void OnDestroy()
        {
            _rotationTween?.Kill();
            _fadeTween?.Kill();
        }
    }
}