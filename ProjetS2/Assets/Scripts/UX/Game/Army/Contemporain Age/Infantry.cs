using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Infantry : Army
    {
        public void Start()
        {
            AttackDamage = 50;
            Health = 140; 
            cost = 60;
            range = 15;
            name = "Infantry";
        }
    }
}
