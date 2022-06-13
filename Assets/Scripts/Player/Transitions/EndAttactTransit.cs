using Assets.Scripts.Player.States;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Transitions
{
    public class EndAttactTransit : PlayerTransition
    {
        [SerializeField] private AttackState _attackState;

        public override void Enabled()
        {
            _attackState.AbillityEnded += OnAbillityEnded;
        }

        private void OnAbillityEnded()
        {
            NeedTransit = true;
        }

        private void OnDisable()
        {
            _attackState.AbillityEnded -= OnAbillityEnded;
        }

        private void Update()
        {

        }
    }
}