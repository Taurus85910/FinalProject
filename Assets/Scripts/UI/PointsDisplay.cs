using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  
   public class PointsDisplay : Display
   {
      [SerializeField] private PlayersPoints _playersPoints;

      private void OnEnable()
      {
         _playersPoints.OnPointChanged += ChangeValue;
      }
      private void OnDisable()
      {
         _playersPoints.OnPointChanged -= ChangeValue;
      }
   }
}