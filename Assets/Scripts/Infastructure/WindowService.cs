using System;
using System.Collections.Generic;
using Services.Data;
using Services.Services;
using UnityEngine;

namespace Services
{
    public class WindowService : MonoBehaviour
    {
        [SerializeField] private RectTransform _canvasUI;

        public event Action OnWindowOpen;

        private Dictionary<WindowType, GameObject> _openedWindows = new();
        private DataService _dataService;
        
        public void Initialize(DataService dataService)
        {
            _dataService = dataService;
        }

        public void OpenWindow(WindowType type)
        {
            if (_openedWindows.ContainsKey(type)) return;

            var prefab = Instantiate(_dataService.Windows[type].Prefab, _canvasUI);
            _openedWindows.Add(type, prefab);
            OnWindowOpen?.Invoke();
        }

        public void CloseWindow(WindowType type)
        {
            if (!_openedWindows.ContainsKey(type)) return;

            Destroy(_openedWindows[type]);
            _openedWindows.Remove(type);
        }

        public void CloseAllWindows()
        {
            foreach (var (key, value) in _openedWindows)
            {
                Destroy(_openedWindows[key]);
            }

            _openedWindows.Clear();
        }

        public bool IsWindowOpen(WindowType type)
        {
            return _openedWindows.ContainsKey(type);
        }
    }
}