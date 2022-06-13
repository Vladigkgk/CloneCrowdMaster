using Assets.Scripts.Components;
using Assets.Scripts.Enemies.States;
using Assets.Scripts.Player;
using Assets.Scripts.Player.States;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemies
{
    public class EnemyStateMachine : PlayerStateMachine, IDamager
    {
        [SerializeField] private BrokenState _brokenState; 
        [SerializeField] private int _minDamage;
        [SerializeField] private HealthComponent _health; 

        public PlayerStateMachine Player { get; private set; }
        public event UnityAction<EnemyStateMachine> KillEnemy;

        protected override void Awake()
        {
            base.Awake();

            Player = FindObjectOfType<PlayerStateMachine>();
        }

        private void OnEnable()
        {
            _health.Died += OnDead;
        }

        private void OnDead()
        {
            enabled = false;
            Rigidbody.constraints = 0;
            KillEnemy?.Invoke(this);
        }

        public bool ApplyDamage(Rigidbody rigidbody, float attackForce)
        {
            if (attackForce > _minDamage && CurrentState != _brokenState)
            {
                _health.TakeDamage((int)attackForce);
                Transit(_brokenState);
                _brokenState.ApplyDamage(rigidbody, attackForce);
                return true;
            }
            return false;
        }

        private void OnDisable()
        {
            _health.Died -= OnDead;
        }
    }
}