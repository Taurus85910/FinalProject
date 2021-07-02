using UnityEngine;
using Player;

namespace UI.Upgrades
{
    public class HealthUpgrader : Upgrader
    {
        [SerializeField] private PlayerHealth _playerHealth;

        public override void Upgrade()
        {
            if (PlayersMoney.Money >= Cost && _playerHealth.Health <= Limit)
            {
                _playerHealth.UpgradeHealth((int) Mathf.Abs(UpgradeVolume));
                PlayersMoney.RemoveMoney(Cost);
            }
        }
    }
}
