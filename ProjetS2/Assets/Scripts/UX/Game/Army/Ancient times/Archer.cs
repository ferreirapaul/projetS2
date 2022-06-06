using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Archer : Army
    {
        void Start()
        {
            AttackDamage = 20;
            Health = 80;
            cost = 20;
        }
    }
}
