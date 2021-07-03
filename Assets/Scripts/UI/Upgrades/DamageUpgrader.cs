using UnityEngine;

namespace UI.Upgrades
{
    public class DamageUpgrader : Upgrader
    {
        [SerializeField] private Shooting _shooting;

        public override void Upgrade()
        {
            if (PlayersMoney.Money >= Cost && _shooting.BulletDamage <= Limit)
            {
                _shooting.UpgradeDamage((int)UpgradeVolume);
                PlayersMoney.RemoveMoney(Cost);
            }
        }
    }
}
