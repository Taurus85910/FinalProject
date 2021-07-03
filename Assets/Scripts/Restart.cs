using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject _restartScreen;
    
    public static event UnityAction OnRestartButtonClick;
    
    public void SetActiveRestartScreen()
    {
        Time.timeScale = 0;
        OnRestartButtonClick?.Invoke();
        _restartScreen.SetActive(true);
    }

    public void Restarting()
    {
        _restartScreen.SetActive(false);
        OnRestartButtonClick?.Invoke();
        Time.timeScale = 1;
    }
}
