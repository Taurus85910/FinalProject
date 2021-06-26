using PlayerScripts;
using UnityEngine;

namespace UI.Upgrades
{
    public abstract class Upgrader : MonoBehaviour
    {
        [SerializeField] protected int Cost;
        [SerializeField] protected float UpgradeVolume;
        [SerializeField] protected PlayersMoney _playersMoney;

        public abstract void Upgrade();
    }
}
