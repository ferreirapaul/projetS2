using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Pike : Army
    {
        public void Start()
        {
            AttackDamage = 30;
            Health = 100;
            cost = 25;
            range = 5;
            name = "Pikeman";
        }
    }
}
