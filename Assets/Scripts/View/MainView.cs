using Services.Data;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private Button _btnLvlUp;

        private void OnEnable()
        {
            _btnLvlUp.onClick.AddListener(OpenLvlUpWindow);
        }
        
        private void OnDisable()
        {
            _btnLvlUp.onClick.RemoveListener(OpenLvlUpWindow);
        }
        
        private void OpenLvlUpWindow()
        {
            GameController.Instance.WindowService.OpenWindow(WindowType.LevelUp);
        }
    }
}