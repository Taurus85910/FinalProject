using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BestPointsUI : MonoBehaviour
    {
        [SerializeField] private string _text;
        [SerializeField] private PlayersPoints _playersPoints;
        [SerializeField] private Text _textField;

        private void OnEnable()
        {
            _textField.text = $"{_text} {_playersPoints.BestPoints}";
        }
    }
}
