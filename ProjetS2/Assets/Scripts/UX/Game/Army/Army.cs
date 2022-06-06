using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Army
{
    public abstract class Army : MonoBehaviour
    {
        public int AttackDamage = 20;
        public int Health = 100;
        public int cost = 15;

        public void ApplyDamage(int AttackDamage)
        {
            Health -= AttackDamage;
            if (Health <= 0)
            {
               Destroy(this);
            }
        }

        public void Attack(Army victim)
        {
            victim.ApplyDamage(AttackDamage);
        }

        void movement(int x, int y)
        {
            transform.position = new Vector2(x, y);
        }
    }
}
