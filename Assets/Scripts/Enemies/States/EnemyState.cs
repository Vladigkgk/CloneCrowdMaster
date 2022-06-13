using Assets.Scripts.DefaultStateMachine.States;
using Assets.Scripts.Player;
using Assets.Scripts.Player.States;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.States
{
    public class EnemyState : MonoBehaviour
    {
        public PlayerStateMachine Player { get; private set; }

    }
}