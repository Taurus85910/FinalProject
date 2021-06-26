using UnityEngine;

namespace UI.Upgrades
{
    public class DamageUpgrader : Upgrader
    {
        [SerializeField] private Shooting _shooting;

        public override void Upgrade()
        {
            if (_playersMoney.Money >= Cost)
            {
                foreach (GameObject i in _shooting.BulletPool)
                {
                    i.GetComponent<Bullet>().UpgradeDamage((int) UpgradeVolume);
                }
                _playersMoney.RemoveMoney(Cost);
            }
        }
    }
}
