using Services.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class RewardUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;

        public void SetImage(IconType type)
        {
            var sprite = GameController.Instance.DataService.Icons[type];
            if (sprite == null) return;

            _image.sprite = sprite;
        }

        public void SetText(RewardStruct reward)
        {
            var text = reward.Title + "<br>";

            if (reward.Add != "")
            {
                text += $"<color=#FEC572ff>+{reward.Add}</color>";
            }
            
            if (reward.X > 0)
            {
                text += $"<color=#FEC572ff>x{reward.X}</color>";
            }

            _text.text = text;
        }
    }
}