using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private GameObject _effectTemplate;
    
    private Vector3 _movePoint;
    private int _heath;

    public event UnityAction<int, int> ShipDestroyed;

    private void Update()
     {
         transform.position = Vector3.MoveTowards(transform.position, _movePoint, _speed * Time.deltaTime);
     }

     private void OnEnable()
     {
         _heath = _maxHealth;
         StartCoroutine(SetNewPoint());
     }
     
     private void OnTriggerEnter2D(Collider2D other) 
     {
        if (other.gameObject.TryGetComponent(out PlayerBullet playerBullet))
        {
            _heath -= playerBullet.Damage;
            if (_heath <= 0)
                DestroyShip();
            playerBullet.gameObject.SetActive(false);
        } 
     }
     
     private void DestroyShip()
     {
         ShipDestroyed?.Invoke(_pointReward,_moneyReward);
         Instantiate(_effectTemplate,transform.position, Quaternion.identity);
         gameObject.SetActive(false);
     }
     
     private IEnumerator SetNewPoint()
     {
         while (true)
         {
             _movePoint = new Vector3(Random.Range(_minPosition.x, _maxPosition.x),Random.Range(_minPosition.y, _maxPosition.y),0);
             yield return new WaitForSeconds(_moveDelay);
         }
     }
}
