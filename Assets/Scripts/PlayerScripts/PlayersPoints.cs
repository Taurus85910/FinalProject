using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerScripts
{
    public class PlayersPoints : MonoBehaviour
    {
        [SerializeField] private int _addedPonitWalue;
        [SerializeField] private float _dealy;

        public event UnityAction<int> OnPointChanged; 
        private int _bestPoints;
        private int _points;
        
        public int BestPoints => _bestPoints;

        private void OnEnable() => Restart.OnRestartButtonClick += ResetPoints;
        private void OnDisable() => Restart.OnRestartButtonClick -= ResetPoints;
       
        private void Start() => StartCoroutine(UpdatePoints());

        private IEnumerator UpdatePoints()
        {
            while (true)
            {
                _points += _addedPonitWalue;
                OnPointChanged?.Invoke(_points);
                yield return new WaitForSeconds(_dealy);
            }
        }
        private void ResetPoints()
        {
            if (_points > _bestPoints) _bestPoints = _points;
            _points = 0;
        }
        public void AddPoints(int points)
        {
            _points += points;
            OnPointChanged?.Invoke(_points);
        }
    }
}
