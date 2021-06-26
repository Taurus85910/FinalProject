using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerCollision))]
    [RequireComponent(typeof(TargetFollower))]
    [RequireComponent(typeof(PolygonCollider2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _maxHeath;
        [SerializeField] private Restart _restart;
        
        public event UnityAction<int> OnHeathChanged; 
        private int _health;
        
        public int Health => _health;
        
        private void Start()
        {
            HealthReset();
        }
        private void OnEnable() => Restart.OnRestartButtonClick += HealthReset;
        private void OnDisable() => Restart.OnRestartButtonClick -= HealthReset;
        public void ApplyDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                if (_health < 0)
                {
                    _health = 0;
                }
                Die();
            }
            OnHeathChanged?.Invoke(_health);
        }
        private void HealthReset()
        {
            _health = _maxHeath;
            OnHeathChanged?.Invoke(_health);
        }
        private void Die()
        {
            _restart.SetActiveRestartScreen();
            _health = _maxHeath;
        }
        public void UpgradeHealth(int upgradeVolume) => _maxHeath += upgradeVolume;
        
    }
}

