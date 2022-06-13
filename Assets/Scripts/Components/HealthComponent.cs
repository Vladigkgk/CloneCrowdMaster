using Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;

        public event UnityAction HealthChanged;
        public event UnityAction Died;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            HealthChanged?.Invoke();
            if (_health < 0)
            {
                Died?.Invoke();
            }
        }
    }
}