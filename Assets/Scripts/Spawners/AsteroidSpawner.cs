using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class AsteroidSpawner : Spawner
    {
        [SerializeField] private GameObject _asteroidTemp;
        [SerializeField] private Vector2 _countBorders;
        [SerializeField] private Vector2 _xBorders;
        [SerializeField] private Vector2 _spawnDelayBorders;
        [SerializeField] private Sprite[] _spritesArray;
        [SerializeField] private int _capacity;
        [SerializeField] private Transform _container;
        [SerializeField] private Vector2 _spawnPosition;
        
        protected override void Start()
        {
            base.Start();
            for (int i = 0; i < _capacity; i++)
            {
                GameObject tempAsteroid = Instantiate(_asteroidTemp,
                    new Vector3(Random.Range(_xBorders.x, _xBorders.y), 0, 0), Quaternion.identity, _container);
                tempAsteroid.GetComponent<SpriteRenderer>().sprite = _spritesArray[Random.Range(0, _spritesArray.Length-1)];
                tempAsteroid.AddComponent<CircleCollider2D>();
                tempAsteroid.GetComponent<Asteroid>().AsteroidDestroyed += OnAsteroidDestroyed;
                Pool.ObjectList.Add(tempAsteroid);
                tempAsteroid.SetActive(false);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Pool.ObjectList.ForEach(asteroid => asteroid.GetComponent<Asteroid>().AsteroidDestroyed -= OnAsteroidDestroyed);
        }

        protected override IEnumerator SpawnPoolElement()
        {
            while (true)
            {
                for (int i = 0; i < Random.Range(_countBorders.x, _countBorders.y); i++)
                {
                    foreach (GameObject asteroid in  Pool.ObjectList.Where(asteroid => !asteroid.activeSelf))
                    {
                        asteroid.SetActive(true);
                        asteroid.transform.position = new Vector3(Random.Range(_xBorders.x, _xBorders.y), _spawnPosition.x, _spawnPosition.y);
                        break;
                    }
                }
                yield return new WaitForSeconds(Random.Range(_spawnDelayBorders.x, _spawnDelayBorders.y));
            }
        }
    }
}
