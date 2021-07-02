using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public abstract class Display : MonoBehaviour
    {
        private Text Text;
        
        private void Start()
        {
            Text = GetComponent<Text>();
        }

        protected void ChangeValue(int value)
        {
            Text.text = value.ToString();
        }
    }
}