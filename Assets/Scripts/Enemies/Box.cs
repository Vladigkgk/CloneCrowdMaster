using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Box : MonoBehaviour, IDamager
    {
        public bool ApplyDamage(Rigidbody rigidbody, float attackForce)
        {
            return false;
        }
    }
}