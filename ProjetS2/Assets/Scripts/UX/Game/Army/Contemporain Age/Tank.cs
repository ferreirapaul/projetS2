using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Tank : Army
    {
        public void Start()
        {
            AttackDamage = 60;
            Health = 200;
            cost = 100;
            range = 60;
            name = "Tank";
        }
    }
}
