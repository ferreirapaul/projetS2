using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Sniper : Army
    {
        public void Start()
        {
            AttackDamage = 60;
            Health = 100;
            cost = 50;
            range = 30;
            name = "Sniper";
        }
    }
}
