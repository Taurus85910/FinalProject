using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> ObjectPool = new List<GameObject>();

        private void OnEnable() => Restart.OnRestartButtonClick += PoolRestart;
        private void OnDisable() => Restart.OnRestartButtonClick -= PoolRestart;

        protected virtual void Start() => StartCoroutine(SpawnPool());

        private void PoolRestart()
        {
            foreach (GameObject poolElement in ObjectPool)
            {
                poolElement.SetActive(false);
            }
        }

        protected abstract IEnumerator SpawnPool();
    }
}
