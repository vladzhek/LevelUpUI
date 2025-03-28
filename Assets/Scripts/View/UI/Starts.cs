using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace View.UI
{
    public class StartsUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private Tween _fadeTween;

        private void Start()
        {
            StartFadeAnimation();
        }

        private void StartFadeAnimation()
        {
            _fadeTween?.Kill();
            
            _fadeTween = _image.DOFade(0, Random.Range(0.5f,1.5f))
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }

        private void OnDestroy()
        {
            _fadeTween?.Kill();
        }
    }
}