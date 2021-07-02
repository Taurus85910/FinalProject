using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class HeathUI : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private Text _text;

        private void OnEnable()
        {
            _playerHealth.OnHeathChanged += ChangeHealth;
        }

        private void OnDisable()
        {
            _playerHealth.OnHeathChanged -= ChangeHealth;
        }

        private void Start()
        {
            _text = GetComponent<Text>();
            _text.text = _playerHealth.Health.ToString();
        }

        private void ChangeHealth(int health)
        {
            _text.text = health.ToString();
        }
    }
}
