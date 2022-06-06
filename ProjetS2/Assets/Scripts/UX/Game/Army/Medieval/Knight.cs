using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Knight : Army
    {
        void Start()
        {
            AttackDamage = 30;
            Health = 140;
            cost = 50;
        }
    }
}
