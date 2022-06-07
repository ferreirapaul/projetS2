using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Archer : Army
    {
        public void Start()
        {
            AttackDamage = 20;
            Health = 80;
            cost = 20;
            range = 4;
            name = "Archer";
        }
    }
}
