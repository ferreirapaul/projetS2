using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Musketeer : Army
    {
        void Start()
        {
            AttackDamage = 40;
            Health = 120;
            cost = 60;
        }
    }
}
