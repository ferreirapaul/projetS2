using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class MissileLauncher : Army
    {
        void Start()
        {
            AttackDamage = 100;
            Health = 100;
            cost = 100;
        }
    }
}