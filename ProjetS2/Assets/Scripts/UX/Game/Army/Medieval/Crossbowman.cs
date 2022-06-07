using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Crossbowman : Army
    {
        public Crossbowman()
        {
            AttackDamage = 40;
            Health = 90;
            cost = 60;
            name = "Crossbowman";
        }
    }
}
