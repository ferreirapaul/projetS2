using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Cavalier : Army
    {
        public void Start()
        {
            AttackDamage = 15;
            Health = 120;
            cost = 25;
            range = 6;
            name = "Cavalier";
        }
    }
}
