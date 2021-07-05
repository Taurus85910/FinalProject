using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _forcePower;
    
    public float ForcePower => _forcePower;
    public int Damage => _damage;

    public void UpgradeDamage(int damageVolume)
    {
        _damage += damageVolume;
    }

    private void Update()
    {
        gameObject.transform.Translate(0, _speed * Time.deltaTime, 0);
    }
}
