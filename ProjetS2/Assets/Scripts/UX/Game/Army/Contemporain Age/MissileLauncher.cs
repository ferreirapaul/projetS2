using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class MissileLauncher : Army
    {
        public void Start()
        {
            AttackDamage = 100;
            Health = 100;
            cost = 100;
            range = 150;
            name = "Missile Launcher";
        }
    }
}