using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Catapult : Army
    {
        public Catapult()
        {
            AttackDamage = 60;
            Health = 100;
            cost = 60;
            name = "Catapult";
        }
    }
}
