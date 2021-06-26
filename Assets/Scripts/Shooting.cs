using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletTemp;
    [SerializeField] private float _shotDelay;
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _tempContainer;
    
    private List<GameObject> _bulletPool = new List<GameObject>();
    private List<Transform> _shootPoints = new List<Transform>();
    
    public List<GameObject> BulletPool => _bulletPool;
    public float ShotDelay => _shotDelay;
    
    public void UpgradeShotDelay(float shotDelayVolume) => _shotDelay -= shotDelayVolume;

    private void OnEnable()
    {
        Restart.OnRestartButtonClick += PoolRestart;
        StartCoroutine(Shot());
    }

    private void OnDisable() => Restart.OnRestartButtonClick -= PoolRestart;

    private void PoolRestart()
    {
        foreach (var i in _bulletPool)
        {
            i.SetActive(false);
        }
    }

    private void Start()
    {
        GameObject container = Instantiate(_tempContainer);
        for (int i = 0; i < _capacity; i++)
        {
            GameObject temp = Instantiate(_bulletTemp,gameObject.transform.position,Quaternion.identity,container.transform);
            temp.SetActive(false);
            _bulletPool.Add(temp);
        }
        InitShotPoints();
    }
    public void InitShotPoints()
    {
        _shootPoints = new List<Transform>();
        foreach (Transform i in transform)
        {
            if (i.gameObject.activeSelf)
            _shootPoints.Add(i);
        }
    }
    private IEnumerator Shot()
    {
        while (true)
        {
            foreach (var i in _shootPoints)
            {
                PoolTaken(i);
            }
            yield return new WaitForSeconds(_shotDelay);
        }
    }
    private void PoolTaken(Transform transform)
    {
        foreach (var i in _bulletPool)
        {
            if (i.activeSelf == false)
            {
                i.SetActive(true);
                i.transform.position = transform.position;
                break;
            }
        }  
    }
}
