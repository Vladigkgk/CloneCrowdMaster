using Assets.Scripts.Player.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayerState _firstState;

        protected PlayerState CurrentState;
        protected Rigidbody Rigidbody;
        protected Animator Animator;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponent<Animator>();
        }

        private void Start()
        {
            CurrentState = _firstState;
            CurrentState.Enter(Rigidbody, Animator);
        }

        private void Update()
        {
            if (CurrentState == null)
                return;

            PlayerState nextState = CurrentState.GetNextState();

            if (nextState != null)
                Transit(nextState);
        }

        protected void Transit(PlayerState nextState)
        {
            if (CurrentState != null)
                CurrentState.Exit();

            CurrentState = nextState;

            if (CurrentState != null)
                CurrentState.Enter(Rigidbody, Animator);

        }


    }
}