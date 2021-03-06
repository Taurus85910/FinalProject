using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

   
   public class MoneyDisplay : Display
   {
      [SerializeField] private PlayersMoney _playersMoney;

      private void OnEnable()
      {
         _playersMoney.MoneyChanged += ChangeValue;
      }
      
      private void OnDisable()
      {
         _playersMoney.MoneyChanged -= ChangeValue;
      }
   }
}
