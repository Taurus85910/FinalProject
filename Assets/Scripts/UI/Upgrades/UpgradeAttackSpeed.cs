using UnityEngine;

namespace UI.Upgrades
{
    public class UpgradeAttackSpeed : Upgrader
    {
        [SerializeField] private Shooting _shooting;

        public override void Upgrade()
        {
            if (_playersMoney.Money >= Cost && _shooting.ShotDelay > 0.2)
            {
                _shooting.UpgradeShotDelay(UpgradeVolume);
                _playersMoney.RemoveMoney(Cost);
            }
        }
    }
}
