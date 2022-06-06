using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Canon : Army
    {
        void Start()
        {
            AttackDamage = 80;
            Health = 100;
            cost = 80;
        }
    }
}
