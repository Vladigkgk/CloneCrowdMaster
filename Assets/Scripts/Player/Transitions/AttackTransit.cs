using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.Transitions
{
    [RequireComponent(typeof(PlayerInput))]
    public class AttackTransit : PlayerTransition
    {
        private PlayerInput _input;

        public override void Enabled()
        {
            _input = GetComponent<PlayerInput>();
            _input.Canceled += OnCanceled;
        }

        private void OnCanceled()
        {
            NeedTransit = true;
        }

        private void Update()
        {
           
        }
    }
}