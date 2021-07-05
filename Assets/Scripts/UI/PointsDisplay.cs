using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  
   public class PointsDisplay : Display
   {
      [SerializeField] private PlayersPoints _playersPoints;

      private void OnEnable()
      {
         _playersPoints.PointChanged += ChangeValue;
      }
      
      private void OnDisable()
      {
         _playersPoints.PointChanged -= ChangeValue;
      }
   }
}