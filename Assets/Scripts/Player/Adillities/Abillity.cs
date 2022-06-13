using Assets.Scripts.Player.States;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player.Adillities
{
    public abstract class Abillity : ScriptableObject
    {
        protected Rigidbody Rigidbody;

        public abstract event UnityAction AbilltyEnded;

        public void Init(Rigidbody rigidbody)
        {
            Rigidbody = rigidbody;
        }

        public abstract void UseAbillity(AttackState attack); 
    }
}