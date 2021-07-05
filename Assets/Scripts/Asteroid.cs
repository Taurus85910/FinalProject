using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] private Vector2 _gravityScaleBorders;
    [SerializeField] private int _minScale;
    [SerializeField] private int _maxScale;
    [SerializeField] private int _healthModifier;
    [SerializeField] private int _massModifier;
    [SerializeField] private int _pointRewardModifier;
    [SerializeField] private int _moneyRewardModifier;
    
    private int _pointReward;
    private int _moneyReward;
    private int _damage;
    private int _health;
    private Rigidbody2D _rigidbody;
    private int _scale;
    
    public int Damage => _damage;
    
    public event UnityAction<int, int> AsteroidDestroyed;

    private void OnEnable()
    {
        _scale = Random.Range(_minScale, _maxScale);
        transform.localScale = new Vector3(_scale, _scale, 1);
        _health = _scale * _healthModifier;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = Random.Range(_gravityScaleBorders.x, _gravityScaleBorders.y) / (Mathf.Log(_scale) + 1);
        _rigidbody.mass = _scale * _massModifier;
        _damage = _scale;
        _pointReward = _scale * _pointRewardModifier;
        _moneyReward = _scale * _moneyRewardModifier;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            _health -= bullet.Damage;

            _rigidbody.gravityScale -= bullet.ForcePower;

            if (_health <= 0)
                DestroyAsteroid();
            bullet.gameObject.SetActive(false);
        }
    }
    
    private void DestroyAsteroid()
    {
        AsteroidDestroyed?.Invoke(_pointReward,_moneyReward);
        gameObject.SetActive(false);
    }
}