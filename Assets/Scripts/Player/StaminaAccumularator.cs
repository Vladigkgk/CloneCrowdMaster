using Assets.Scripts.Player.Adillities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class StaminaAccumularator : MonoBehaviour
    {
        [SerializeField] private float _acumulatorTime;
        [SerializeField] private Abillity _abillity;
        [SerializeField] private Abillity _ultimateAbillity;

        private float _startAcumulator;
         
        public void StartAcumulator()
        {
            _startAcumulator = 0;
        }

        private void Update()
        {
            _startAcumulator += Time.deltaTime;
        }

        public Abillity GetAbbillity()
        {
            if (_startAcumulator > _acumulatorTime)
            {
                return _ultimateAbillity;
            }
            return _abillity;


        }
    }
}