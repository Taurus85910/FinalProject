using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Spawners
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> ObjectPool = new List<GameObject>();
        
        public List<GameObject> GetList => ObjectPool;
        
        public event UnityAction<int, int> OnElementDestroyed;
        
        protected void OnEnable()
        {
            Restart.OnRestartButtonClick += PoolRestart;
        }

        protected virtual void OnDisable()
        {
            Restart.OnRestartButtonClick -= PoolRestart;
        }

        protected virtual void Start()
        {
            StartCoroutine(SpawnPoolElement());
        }

        private void PoolRestart()
        {
            foreach (GameObject poolElement in ObjectPool)
            {
                poolElement.SetActive(false);
            }
        }
        
        protected void InvokeEvent(int points,int money)
        {
            OnElementDestroyed?.Invoke(points,money);
        }

        protected abstract IEnumerator SpawnPoolElement();
    }
}
