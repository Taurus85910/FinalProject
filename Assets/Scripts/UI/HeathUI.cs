using PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class HeathUI : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Text _text;

        private void OnEnable() => _player.OnHeathChanged += ChangeHealth;
        private void OnDisable() => _player.OnHeathChanged -= ChangeHealth;

        private void Start()
        {
            _text = GetComponent<Text>();
            _text.text = _player.Health.ToString();
        }

        private void ChangeHealth(int health) => _text.text = health.ToString();
    }
}
