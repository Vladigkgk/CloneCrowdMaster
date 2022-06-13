using Assets.Scripts.Player.States;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemies.States
{
    public class BrokenState : PlayerState
    {
        [SerializeField] private float _fallDistance = 5f;

        public event UnityAction Died;

        public void ApplyDamage(Rigidbody rigidbody, float attackForce)
        {
            Debug.Log(attackForce);
            Vector3 diretion = transform.position - rigidbody.position;
            diretion.y = 0;
            Rigidbody.AddForce(diretion.normalized * attackForce, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, _fallDistance) == false)
            {
                Died?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (enabled == false)
                return;

            if (other.TryGetComponent(out IDamager damager))
            {
                damager.ApplyDamage(Rigidbody, Rigidbody.velocity.magnitude);
            }
        }
    }
}