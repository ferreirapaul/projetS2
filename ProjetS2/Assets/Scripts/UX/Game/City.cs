using System.Collections.Generic;

namespace Game
{
    public class  City
    {
        private int health;
        public int ID;
        private Player owner;
        private List<Building.Building> builtBuildings;

        public int Health
        {
            get => this.health;
            set => this.health = value;
        }

        public Player Owner
        {
            get => this.owner;
            set => this.owner = value;
        }

        public City(Player Owner)
        {
            this.health = 100;
            this.owner = Owner;
            this.builtBuildings = new List<Building.Building>();
        }
        
        
    }
}