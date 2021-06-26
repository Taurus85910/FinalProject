using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

   
   public class MoneyDisplay : Display
   {
      [SerializeField] private PlayersMoney _playersMoney;

      private void OnEnable()
      {
         _playersMoney.OnMoneyChanged += ChangeValue;
      }
      private void OnDisable()
      {
         _playersMoney.OnMoneyChanged -= ChangeValue;
      }
   }
}
