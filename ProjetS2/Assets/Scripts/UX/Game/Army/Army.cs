using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Army
{
    public abstract class Army
    {
        public int AttackDamage;
        public int Health;
        public int cost;

        public Army()
        {
            this.AttackDamage = 20;
            this.Health = 100;
            this.cost = 15;
        }

        public void ApplyDamage(int AttackDamage)
        {
            Health -= AttackDamage;
            if (Health <= 0)
            {
               //Todo destroy
            }
        }

        public void Attack(Army victim)
        {
            victim.ApplyDamage(AttackDamage);
        }

        void movement(int x, int y)
        {
            //TODO mouv
        }
    }
}
