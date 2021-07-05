using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private float _shotDelay;
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _tempContainer;
    
    private readonly List<Bullet> _bulletPool = new List<Bullet>();
    private List<Transform> _shootPoints = new List<Transform>();
    
    public float ShotDelay => _shotDelay;
    public int BulletDamage => _bulletPool[1].Damage;

    public void UpgradeDamage(int upgradeVolume)
    {
        _bulletPool.ForEach(bullet => bullet.UpgradeDamage(upgradeVolume));
    }

    public void UpgradeShotDelay(float shotDelayVolume)
    {
        _shotDelay -= shotDelayVolume;
    }

    private void OnEnable()
    {
        Restart.RestartButtonClicked += PoolRestart;
        StartCoroutine(Shot());
    }

    private void OnDisable()
    {
        Restart.RestartButtonClicked -= PoolRestart;
    }

    private void PoolRestart()
    {
        foreach (var bullet in _bulletPool)
        {
            bullet.GameObject().SetActive(false);
        }
    }

    private void Start()
    {
        GameObject container = Instantiate(_tempContainer);
        for (int i = 0; i < _capacity; i++)
        {
            GameObject temp = Instantiate(_bulletTemplate,gameObject.transform.position,Quaternion.identity,container.transform);
            temp.SetActive(false);
            _bulletPool.Add(temp.GetComponent<Bullet>());
        }
        InitShotPoints();
    }
    
    public void InitShotPoints()
    {
        _shootPoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf) 
                _shootPoints.Add(child);
        }
    }
    
    private IEnumerator Shot()
    {
        while (true)
        {
            foreach (var shootPoint in _shootPoints)
            {
                PoolTaken(shootPoint);
            }
            yield return new WaitForSeconds(_shotDelay);
        }
    }
    
    private void PoolTaken(Transform transform)
    {
        foreach (Bullet bullet in _bulletPool)
        {
            if (bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = transform.position;
                break;
            }
        }  
    }
}
