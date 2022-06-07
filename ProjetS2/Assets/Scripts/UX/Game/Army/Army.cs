using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Army
{
    public abstract class Army : MonoBehaviour
    {
        public int AttackDamage;
        public int Health;
        public GenMapScript genMapScript;
        public int cost;
        public int coastEachTurn;
        public string name;
        public int range;

        public string Name => this.name;

        public void Start()
        {
            this.genMapScript = GameObject.FindObjectOfType<GenMapScript>();
            this.AttackDamage = 20;
            this.Health = 100;
            this.cost = 15;
            this.coastEachTurn = 2;
            this.range = 5;
            
            this.name = "";
        }
        

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
            genMapScript.map.AddVision(x,y,range);
        }
    }
}
