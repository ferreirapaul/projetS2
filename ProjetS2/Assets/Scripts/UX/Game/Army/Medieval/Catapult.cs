using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Catapult : Army
    {
        void Start()
        {
            AttackDamage = 60;
            Health = 100;
            cost = 60;
        }
    }
}
