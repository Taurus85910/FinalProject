using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] private Vector2 _GravityScaleBorders;
    [SerializeField] private int _minScale;
    [SerializeField] private int _maxScale;
    private int _pointReward;
    private int _moneyReward;
    private int _damage;
    private int _health;
    private Rigidbody2D _rigidbody;
    private PlayersMoney _playersMoney;
    private PlayersPoints _playersPoints;
    private int _scale;
    
    public int Damage => _damage;
    private void OnEnable()
    {
        _scale = Random.Range(_minScale, _maxScale);
        transform.localScale = new Vector3(_scale, _scale, 1);
        _health = _scale * 20;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = Random.Range(_GravityScaleBorders.x, _GravityScaleBorders.y) / (Mathf.Log(_scale) + 1);
        _rigidbody.mass = _scale * 100;
        _damage = _scale;
        _pointReward = _scale * 10;
        _moneyReward = _scale;
    }
    private void Start()
    {
        _playersMoney = FindObjectOfType<PlayersMoney>();
        _playersPoints = FindObjectOfType<PlayersPoints>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            _health -= bullet.Damage;

            _rigidbody.gravityScale -= bullet.ForcePower;

            if (_health <= 0)
                OnAsteroidDestroy();
            bullet.gameObject.SetActive(false);
        }
    }
    private void OnAsteroidDestroy()
    {
        _playersMoney.AddMoney(_moneyReward);
        _playersPoints.AddPoints(_pointReward);
        gameObject.SetActive(false);
    }
}