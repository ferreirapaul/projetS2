using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Tank : Army
    {
        void Start()
        {
            AttackDamage = 60;
            Health = 200;
            cost = 100;
        }
    }
}
