using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Army
{
    public class Knight : Army
    {
        public void Start()
        {
            AttackDamage = 30;
            Health = 140;
            cost = 50;
            range = 12;
            name = "Knight";
        }
    }
}
