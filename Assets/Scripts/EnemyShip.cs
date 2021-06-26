using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShip : MonoBehaviour
{
     
    [SerializeField] private int _maxHealth;
    [SerializeField] private Vector2 _minPosition;
    [SerializeField] private Vector2 _maxPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _moveDelay;
    [SerializeField] private int _moneyReward;
    [SerializeField] private int _pointReward;
    
    private Vector3 _movePoint;
    private PlayersMoney _playersMoney;
    private PlayersPoints _playersPoints;
    private int _heath;

    private void Start()
    {
        _playersMoney = FindObjectOfType<PlayersMoney>();
        _playersPoints = FindObjectOfType<PlayersPoints>();
    }
     private void Update() => transform.position = Vector3.MoveTowards( transform.position, _movePoint, 
         _speed * Time.deltaTime);
     private void OnEnable()
     {
         _heath = _maxHealth;
         StartCoroutine(SetNewPoint());
     }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.TryGetComponent(out Bullet bullet) && !(bullet.IsEnemyBullet)))
        {
            _heath -= bullet.Damage;
            if (_heath <= 0)
                OnShipDestroy();
            bullet.gameObject.SetActive(false);
        }
    }
     private void OnShipDestroy()
     {
         _playersMoney.AddMoney(_moneyReward);
         _playersPoints.AddPoints(_pointReward);
         gameObject.SetActive(false);
     }
     private IEnumerator SetNewPoint()
     {
         while (true)
         {
             //print(new Vector3(Random.Range(_minPosition.x, _maxPosition.x),Random.Range(_minPosition.y, _maxPosition.y),0));

             _movePoint = new Vector3(Random.Range(_minPosition.x, _maxPosition.x),Random.Range(_minPosition.y, _maxPosition.y),0);
             yield return new WaitForSeconds(_moveDelay);
         }
     }
}
