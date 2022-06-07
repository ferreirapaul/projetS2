using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Hoplite : Army
    {
        public void Start()
        {
            AttackDamage = 15;
            Health = 100;
            cost = 15;
            name = "Hoplite";
        }
    }
}
