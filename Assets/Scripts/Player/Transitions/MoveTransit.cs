using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.Transitions
{
    [RequireComponent(typeof(PlayerInput))]
    public class MoveTransit : PlayerTransition
    {
        private PlayerInput _input;

        public override void Enabled()
        {
            _input = GetComponent<PlayerInput>();
            _input.Started += OnStarted;
        }

        private void OnStarted()
        {
            NeedTransit = true;

        }

        private void Update()
        {            
           
        }
    }
}