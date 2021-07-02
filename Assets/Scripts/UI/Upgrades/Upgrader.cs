using Player;
using UnityEngine;

namespace UI.Upgrades
{
    public abstract class Upgrader : MonoBehaviour
    {
        [SerializeField] protected int Cost;
        [SerializeField] protected float UpgradeVolume;
        [SerializeField] protected PlayersMoney PlayersMoney;
        [SerializeField] protected float Limit;

        public abstract void Upgrade();
    }
}
