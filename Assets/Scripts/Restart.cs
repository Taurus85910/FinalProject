using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject _restartScreen;
    
    public static event UnityAction RestartButtonClicked;
    
    public void SetActiveRestartScreen()
    {
        Time.timeScale = 0;
        RestartButtonClicked?.Invoke();
        _restartScreen.SetActive(true);
    }

    public void Restarting()
    {
        _restartScreen.SetActive(false);
        RestartButtonClicked?.Invoke();
        Time.timeScale = 1;
    }
}
