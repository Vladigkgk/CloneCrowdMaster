using Assets.Scripts.Player.States;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player.Adillities
{
    [CreateAssetMenu(fileName = "HandAbillity", menuName = "Abillity")]
    public class HandAbillity : Abillity
    {
        [SerializeField] private float _attackForce;
        [SerializeField] private float _usefulTime;

        private AttackState _state;
        private Coroutine _coroutine;


        public override event UnityAction AbilltyEnded;

        private void OnPlayerAttack(IDamager damager)
        {
            if (damager.ApplyDamage(_state.Rigidbody, _attackForce))
                return;

            _state.Rigidbody.velocity /= 2;
        }

        public override void UseAbillity(AttackState attack)
        {
            if (_coroutine != null)
                StopAbillity();

            _state = attack;

            _coroutine = _state.StartCoroutine(Attack(_state));
            _state.CollisitionDetected += OnPlayerAttack;
        }

        private IEnumerator Attack(AttackState state)
        {
            float time = _usefulTime;

            while (time > 0)
            {
                state.Rigidbody.velocity = state.Rigidbody.velocity.normalized * _attackForce;
                time -= Time.deltaTime;
                yield return null;
            }

            AbilltyEnded?.Invoke();
        }

        private void StopAbillity()
        {
            _state.Rigidbody.velocity = Vector3.zero;
            _state.StopCoroutine(_coroutine);
            _coroutine = null;
            _state.CollisitionDetected -= OnPlayerAttack;
        }


    }
}