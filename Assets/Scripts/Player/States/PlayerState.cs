using Assets.Scripts.Player.Transitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.States
{
    public abstract class PlayerState : MonoBehaviour
    {
        [SerializeField] protected PlayerTransition[] _transitions;

        public Rigidbody Rigidbody { get; private set; }
        protected Animator Animator { get; private set; }

        public virtual PlayerState GetNextState()
        {
            foreach (var transition in _transitions)
            {
                if (transition.NeedTransit)
                {
                    return transition.TargetState;
                }
            }

            return null;
        }

        public virtual void Enter(Rigidbody rigidbody, Animator animator)
        {
            if (enabled == false)
            {
                Rigidbody = rigidbody;
                Animator = animator;

                enabled = true;

                foreach (var transition in _transitions)
                {
                    transition.enabled = true;
                }
            }
        }

        public void Exit()
        {
            if (enabled == true)
            {
                foreach (var transition in _transitions)
                {
                    transition.enabled = false;
                }

                enabled = false;
            }
        }
    }
}