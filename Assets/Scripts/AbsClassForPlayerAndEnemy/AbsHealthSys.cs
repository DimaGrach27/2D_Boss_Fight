using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player_and_Enemy_Control
{
    public abstract class AbsHealthSys : MonoBehaviour
    {
      
        public float MaxHealth { get; set; }

        public abstract void Damaget(float amount);

    }

    public abstract class AbsMoventSys : MonoBehaviour
    {
        public float Speed { get; set; }
        public float JumpForce { get; set; }

    }

    public abstract class AbsBattletSys : MonoBehaviour
    {
        public float Damage { get; set; }

    }
}

