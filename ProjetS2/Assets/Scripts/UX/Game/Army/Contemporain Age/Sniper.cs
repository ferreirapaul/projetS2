using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Sniper : Army
    {
        public Sniper()
        {
            AttackDamage = 60;
            Health = 100;
            cost = 50;
            name = "Sniper";
        }
    }
}
