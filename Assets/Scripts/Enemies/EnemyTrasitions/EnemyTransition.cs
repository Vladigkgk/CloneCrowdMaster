using Assets.Scripts.Player;
using Assets.Scripts.Player.Transitions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.EnemyTrasitions
{
    public class EnemyTransition : PlayerTransition
    {

        protected PlayerStateMachine Player { get; private set; }

        public void Init(PlayerStateMachine player)
        {
            Player = player;
        }

        public override void Enabled()
        {
            
        }
    }
}