using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Canon : Army
    {
        public void Start()
        {
            AttackDamage = 80;
            Health = 100;
            cost = 80;
            range = 6;
            name = "Canon";
        }
    }
}
