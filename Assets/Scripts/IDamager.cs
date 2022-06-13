using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IDamager 
    {
        public bool ApplyDamage(Rigidbody rigidbody, float attackForce);
    }
}