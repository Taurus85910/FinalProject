using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Spawners
{
    public abstract class Spawner: MonoBehaviour 
    {
        [SerializeField] protected ObjectPool Pool;
        
        public event UnityAction<int, int> ElementDestroyed;
        
        protected void OnEnable()
        {
            Restart.RestartButtonClicked += Pool.OnRestartButtonClicked;
        }

        protected virtual void OnDisable()
        {
            Restart.RestartButtonClicked -= Pool.OnRestartButtonClicked;
        }

        protected virtual void Start()
        {
            StartCoroutine(SpawnPoolElement());
        }

        
        
        protected void OnAsteroidDestroyed(int points,int money)
        {
            ElementDestroyed?.Invoke(points,money);
        }

        protected abstract IEnumerator SpawnPoolElement();
    }
}
