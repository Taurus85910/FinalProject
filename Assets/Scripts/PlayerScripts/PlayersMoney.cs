using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerScripts
{
    public class PlayersMoney : MonoBehaviour
    {
        [SerializeField] private MoneyDisplay _moneyDisplay;

        public event UnityAction<int> OnMoneyChanged; 
        private int _money;
        
        public int Money => _money;

        public void AddMoney(int moneyVolume)
        {
            _money += moneyVolume;
            OnMoneyChanged?.Invoke(_money);
        }
        public void RemoveMoney(int removeVolume)
        {
            _money -= removeVolume;
            OnMoneyChanged?.Invoke(_money);
        }
    }
}
