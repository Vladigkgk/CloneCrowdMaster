using Assets.Scripts.Player.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Transitions
{
    public abstract class PlayerTransition : MonoBehaviour
    {
        [SerializeField] private PlayerState _targetState;

        public PlayerState TargetState => _targetState;
        public bool NeedTransit { get; protected set; }

        public abstract void Enabled();

        protected virtual void OnEnable()
        {
            NeedTransit = false;
            Enabled();
        }

    }
}