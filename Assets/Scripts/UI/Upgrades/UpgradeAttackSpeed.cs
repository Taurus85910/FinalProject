using UnityEngine;

namespace UI.Upgrades
{
    public class UpgradeAttackSpeed : Upgrader
    {
        [SerializeField] private Shooting _shooting;

        public override void Upgrade()
        {
            if (PlayersMoney.Money >= Cost && _shooting.ShotDelay >= Limit)
            {
                _shooting.UpgradeShotDelay(Mathf.Abs(UpgradeVolume));
                PlayersMoney.RemoveMoney(Cost);
            }
        }
    }
}
