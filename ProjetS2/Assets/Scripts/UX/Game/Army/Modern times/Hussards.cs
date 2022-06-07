using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Hussards : Army
    {
        public void Start()
        {
            AttackDamage = 40;
            Health = 160;
            cost = 70;
            range = 6;
            name = "Hussard";
        }
    }
}
