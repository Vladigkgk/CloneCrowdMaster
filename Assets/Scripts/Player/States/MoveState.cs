using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.States
{
    [RequireComponent(typeof(PlayerInput))]
    public class MoveState : PlayerState
    {
        [SerializeField] private StaminaAccumularator _stamina;
        [SerializeField] private float _speed;

        private PlayerInput _input;
        private static int IsRunning => Animator.StringToHash("isRunning");

        private void OnEnable()
        {
            Animator.SetBool(IsRunning, true);
            _stamina.StartAcumulator();
            _input = GetComponent<PlayerInput>();
        }

        private void FixedUpdate()
        {
            if (_input.Diration.magnitude > 0.3f)
            {
                MovePosition(_input.Diration.normalized);
            }
        }

        private void MovePosition(Vector2 diretion)
        {
            Rigidbody.velocity = new Vector3(diretion.x, 0, diretion.y) * _speed;
            Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));             
        }

        private void OnDisable()
        {
            Animator.SetBool(IsRunning, false);
        }

    }
}