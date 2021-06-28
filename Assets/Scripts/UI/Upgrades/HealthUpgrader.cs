using UnityEngine;
using PlayerScripts;

namespace UI.Upgrades
{
    public class HealthUpgrader : Upgrader
    {
        [SerializeField] private Player _player;

        public override void Upgrade()
        {
            if (_playersMoney.Money >= Cost && _player.Health <= Limit)
            {
                _player.UpgradeHealth((int) UpgradeVolume);
                _playersMoney.RemoveMoney(Cost);
            }
        }
    }
}
