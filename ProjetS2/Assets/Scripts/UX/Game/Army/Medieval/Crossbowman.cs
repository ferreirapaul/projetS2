using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Crossbowman : Army
    {
        public void Start()
        {
            AttackDamage = 40;
            Health = 90;
            cost = 60;
            range = 6;
            name = "Crossbowman";
        }
    }
}
