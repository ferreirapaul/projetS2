using System.Collections;
using System.Collections.Generic;
using Ressources;
using Army;
using Technology;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public LobbyInfos lobbby;
        public GenMapScript map;
        public List<Ressources.Ressources> ressources;
        public List<Building.Building> availableBuildings;
        public List<Army.Army> availableArmy;
        public List<Technology.Technology> listTechno;

        void Start()
        {
            //map.Generate(lobbby.Seed);
            lobbby = (LobbyInfos) GameObject.FindObjectOfType(typeof(LobbyInfos));
            Initiate();
        }

        void Initiate()
        {
            ressources = new List<Ressources.Ressources>();
            ressources.Add(new Gold());
            ressources.Add(new Food());
            ressources.Add(new Population());
            ressources.Add(new ProductionPoints());
            ressources.Add(new Sciences());
            availableBuildings = new List<Building.Building>();
            availableArmy = new List<Army.Army>();
            listTechno = new List<Technology.Technology>();
            listTechno.Add(new Aqueduct(ressources,availableBuildings,availableArmy));
            listTechno.Add(new ArmyC(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Bow(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Ebeniste(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Equitation(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Forge(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Market(ressources,availableBuildings,availableArmy));
            listTechno.Add(new School(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Catapult(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Crossbow(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Feudalism(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Knight(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Knight(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Mill(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Pike(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Religion(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Wall(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Cannon(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Halberdier(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Hussar(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Lumieres(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Musketeers(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Napoleon(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Revolution(ressources,availableBuildings,availableArmy));
            listTechno.Add(new SteamMachine(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Computer(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Comunism(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Globalization(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Infantry(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Missiles(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Oil(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Sniper(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Tank(ressources,availableBuildings,availableArmy));

        }

        
    }
}
