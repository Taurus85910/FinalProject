using System.Collections;
using System.Collections.Generic;
using UI.Upgrades;
using UnityEngine;

namespace UI.Upgrades
{

    public class AdditionalShotPoint : Upgrader
    {
        [SerializeField] private GameObject _shotPoint;
        [SerializeField] private Shooting _shooting;
        
        public override void Upgrade()
        {
            if (PlayersMoney.Money >= Cost)
            {
                _shotPoint.SetActive(true);
                PlayersMoney.RemoveMoney(Cost);
                _shooting.InitShotPoints();
                gameObject.SetActive(false);
            }
        }
    }
}
