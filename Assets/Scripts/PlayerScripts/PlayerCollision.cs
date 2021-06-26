using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private float _forcePower;
        
        private Player _player;
        private PolygonCollider2D _polygonCollider2D;

        private void Start()
        {
            _player = GetComponent<Player>();
            _polygonCollider2D = GetComponent<PolygonCollider2D>();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out Asteroid asteroid)) return;
            CollisionHandler(asteroid, other);
            _player.ApplyDamage(asteroid.Damage);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(out Bullet bullet) || !bullet.IsEnemyBullet) return;
            _player.ApplyDamage(bullet.Damage);
            bullet.gameObject.SetActive(false);
        }
        private IEnumerator DisableFollow()
        {
            _polygonCollider2D.enabled = false;
            yield return new WaitForSeconds(0.5f);
            _polygonCollider2D.enabled = true;
        }
        private void CollisionHandler(Asteroid asteroid, Collision2D collision2D)
        {
            Rigidbody2D asteroidRigidbody2D = asteroid.gameObject.GetComponent<Rigidbody2D>();
            Vector3 position = collision2D.transform.position;
            asteroidRigidbody2D.AddForce(
                ((Vector2) position - collision2D.contacts[0].point).normalized * asteroidRigidbody2D.mass *
                _forcePower, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().AddForce(
                (collision2D.contacts[0].point - (Vector2) position).normalized * _forcePower, ForceMode2D.Impulse);
            StartCoroutine(DisableFollow());
            StopCoroutine(DisableFollow());
        }
    }
}
