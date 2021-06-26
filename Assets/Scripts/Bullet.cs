using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _forcePower;
    [SerializeField] private bool _isEnemyBullet;
    
    public bool IsEnemyBullet => _isEnemyBullet;
    public float ForcePower => _forcePower;
    public int Damage => _damage;

    public void UpgradeDamage(int damageVolume) => _damage += damageVolume;

    private void Update() => gameObject.transform.Translate(0,_speed * Time.deltaTime,0);
}
