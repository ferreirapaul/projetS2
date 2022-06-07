using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Belier : Army
    {
        public void Start()
        {
            AttackDamage = 40;
            Health = 50;
            cost = 40;
            range = 1;
            name = "Belier";
        }
    }
}
