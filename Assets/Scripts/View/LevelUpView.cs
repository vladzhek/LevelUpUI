using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Services.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using View.UI;

namespace View
{
    public class LevelUpView : MonoBehaviour
    {
        [SerializeField] private RectTransform _rewardGroup;
        [SerializeField] private RectTransform _2xRewardGroup;
        [SerializeField] private GameObject _rewardUI;
        
        [SerializeField] private Button _get;
        [SerializeField] private Button _claim;
        [SerializeField] private TMP_Text _textLVl;
        
        private RectTransform _rectTransform;
        private Vector3 _originalScale;
        private Tween _currentTween;
        private float overshoot = 1.1f;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _originalScale = _rectTransform.localScale;
            _rectTransform.localScale = Vector3.zero;
        }

        private void OnEnable()
        {
            ShowPanel();
            _get.onClick.AddListener(CloseWindow);
            _claim.onClick.AddListener(CloseWindow);
            _textLVl.text = $"- Level {GameController.Instance.DataService.Level} -";
            UpdateRewardGroup(_rewardGroup, "1");
            UpdateRewardGroup(_2xRewardGroup, "2");
        }

        private void OnDisable()
        {
            _get.onClick.RemoveListener(CloseWindow);
            _claim.onClick.RemoveListener(CloseWindow);
            
            GameController.Instance.DataService.Level++;
        }
        
        private void ShowPanel()
        {
            _currentTween?.Kill();
            var showDuration = 0.5f;
            gameObject.SetActive(true);
            
            _currentTween = _rectTransform.DOScale(_originalScale * overshoot, showDuration * 0.7f)
                .SetEase(Ease.OutSine)
                .OnComplete(() => {
                    _rectTransform.DOScale(_originalScale, showDuration * 0.3f)
                        .SetEase(Ease.OutBack);
                });
        }

        private void UpdateRewardGroup(RectTransform rewardGroup, string rewardID)
        {
            var listRewards = GameController.Instance.DataService.Rewards[rewardID];
            foreach (var reward in listRewards)
            {
                var prefab = Instantiate(_rewardUI, rewardGroup).GetComponent<RewardUI>();
                prefab.SetImage(reward.Icon);
                prefab.SetText(reward);
            }
        }
        
        private void CloseWindow()
        {
            HidePanel();
        }
        
        private void HidePanel()
        {
            _currentTween?.Kill();
            
            _currentTween = _rectTransform.DOScale(Vector3.zero, 0.3f)
                .SetEase(Ease.InBack)
                .OnComplete(() => GameController.Instance.WindowService.CloseWindow(WindowType.LevelUp));
        }
    }
}