using UnityEngine;

namespace UI.Upgrades
{
    public class DamageUpgrader : Upgrader
    {
        [SerializeField] private Shooting _shooting;

        public override void Upgrade()
        {
            if (PlayersMoney.Money >= Cost && _shooting.BulletPool[1].GetComponent<Bullet>().Damage <= Limit)
            {
                foreach (GameObject i in _shooting.BulletPool)
                {
                    i.GetComponent<Bullet>().UpgradeDamage((int) Mathf.Abs(UpgradeVolume));
                }
                PlayersMoney.RemoveMoney(Cost);
            }
        }
    }
}
