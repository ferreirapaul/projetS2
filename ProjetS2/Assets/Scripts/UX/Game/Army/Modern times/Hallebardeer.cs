using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Hallebardeer : Army
    {
        public void Start()
        {
            AttackDamage = 40;
            Health = 120;
            cost = 40;
            range = 5;
            name = "Hallebardeer";
        }
    }
}
