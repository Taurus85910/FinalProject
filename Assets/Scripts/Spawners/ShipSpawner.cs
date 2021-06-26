using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class ShipSpawner : Spawner
    {
        [SerializeField] private float _spawnDelay;
        [SerializeField] private float _chaoticModifier;
        [SerializeField] private Vector2 _spawnPosition;

        protected override void Start()
        {
            for (int i = 0; i < ObjectPool.Count; i++)
            {
                ObjectPool[i] = Instantiate(ObjectPool[i], transform.position, Quaternion.Euler(180, 0, 0));
                ObjectPool[i].SetActive(false);
            }

            base.Start();
        }

        protected override IEnumerator SpawnPool()
        {
            while (true)
            {
                int shipNum = Random.Range(0, ObjectPool.Count);
                ObjectPool[shipNum].SetActive(true);
                ObjectPool[shipNum].transform.position = _spawnPosition;
                yield return new WaitForSeconds(_spawnDelay + Random.Range(-_chaoticModifier, _chaoticModifier));
            }
        }
    }
}
