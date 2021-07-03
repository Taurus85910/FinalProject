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
    
    private readonly List<GameObject> _bulletPool = new List<GameObject>();
    private List<Transform> _shootPoints = new List<Transform>();
    
    public float ShotDelay => _shotDelay;
    public int BulletDamage => _bulletPool[1].GetComponent<Bullet>().Damage;

    public void UpgradeDamage(int upgradeVolume)
    {
        _bulletPool.ForEach(bullet => bullet.GetComponent<Bullet>().UpgradeDamage(upgradeVolume));
    }

    public void UpgradeShotDelay(float shotDelayVolume)
    {
        _shotDelay -= shotDelayVolume;
    }

    private void OnEnable()
    {
        Restart.OnRestartButtonClick += PoolRestart;
        StartCoroutine(Shot());
    }

    private void OnDisable()
    {
        Restart.OnRestartButtonClick -= PoolRestart;
    }

    private void PoolRestart()
    {
        foreach (var bullet in _bulletPool)
        {
            bullet.SetActive(false);
        }
    }

    private void Start()
    {
        GameObject container = Instantiate(_tempContainer);
        for (int i = 0; i < _capacity; i++)
        {
            GameObject temp = Instantiate(_bulletTemplate,gameObject.transform.position,Quaternion.identity,container.transform);
            temp.SetActive(false);
            _bulletPool.Add(temp);
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
        foreach (GameObject bullet in _bulletPool)
        {
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
                break;
            }
        }  
    }
}
