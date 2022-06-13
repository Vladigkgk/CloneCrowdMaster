using Assets.Scripts.Player.Adillities;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player.States
{
    public class AttackState : PlayerState
    {
        [SerializeField] private StaminaAccumularator _stamina;

        private Abillity _currentAbillity;
        private static int KickTrigger => Animator.StringToHash("Kick");

        public event UnityAction<IDamager> CollisitionDetected;
        public event UnityAction AbillityEnded;

        private void OnEnable()
        {
            Animator.SetTrigger(KickTrigger);

            _currentAbillity = _stamina.GetAbbillity();
            _currentAbillity.AbilltyEnded += OnAbillityEnded;
            _currentAbillity.Init(Rigidbody);

            _currentAbillity.UseAbillity(this);
        }

        private void OnAbillityEnded()
        {
            AbillityEnded?.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out IDamager damager))
            {
                CollisitionDetected?.Invoke(damager);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamager damager))
            {
                CollisitionDetected?.Invoke(damager);
            }
        }

        private void Update()
        {
            
        }

        private void OnDisable()
        {
            _currentAbillity.AbilltyEnded -= OnAbillityEnded;
        }

    }
}