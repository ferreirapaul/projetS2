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
        public Game.Game game;
        public int cost;
        public int coastEachTurn;
        public string name;
        public int range;
        public bool IsEnemy;
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
        public void AttackCity(City victim)
        {
            victim.Health -= AttackDamage;
            if (victim.Health <= 0)
            {
                victim.Owner = game.citiesOwn[0].Owner;
                victim.Health = 100;
                game.citiesOwn.Add(victim);
            }
        }

        public void movement(int startx, int starty,int endx,int endy,int i)
        {
            int x = endx - startx;
            int y = endy - endx;
            y = y < 0 ? -y : y;
            x = x < 0 ? -x : x;
            if (this.range>=x+y)
            {
                genMapScript.map.AddVision(endx,endy,range);
                int ind = 0;
                int j = 0;
                bool enemyhere = false;
                List<(int, int)> pos = new List<(int, int)>() { (endx, endy), (endx - 1, endy), (endx, endy - 1), (endx - 1, endy - 1) };
                while (ind<game.UnlockArmy.Count&&!enemyhere)
                {
                    j = 0;
                    while (j<4&& !enemyhere)
                    {
                        enemyhere = game.UnlockArmy[ind].transform.localPosition.x == pos[j].Item1 && game.UnlockArmy[ind].transform.localPosition.y == pos[j].Item2;
                        j++;
                    }
                    ind++;
                }
                j = 0;
                Map map = genMapScript.map;
                int owner = game.citiesOwn[0].Owner.Id;
                bool enemyciti = true;
                while (j < map.ListOfCities.Count && enemyciti && !enemyhere)
                {

                    GameObject citi = map.ListOfCities[j].gameObject;

                    enemyciti = citi.transform.localPosition.x == endx && citi.transform.localPosition.y == endy && map.ListOfCities[j].Owner.Id!=owner;

                    j++;
                }
                if (enemyhere)
                {
                    this.Attack(game.UnlockArmy[ind]);
                } 
                else
                {
                    if (enemyciti)
                    {
                        this.AttackCity(map.ListOfCities[j]);
                    }
                    else
                    {
                        game.UnlockArmy[i].transform.localPosition = new Vector3(endy, endx, 2);
                    }  
  
                }
                
            }
            
        }
    }
}
