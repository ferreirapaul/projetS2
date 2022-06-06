using System.Collections;
using System.Collections.Generic;
using Ressources;
using Army;
using Network;
using Technology;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public Text Won;
        public LobbyInfos lobbby;
        public GenMapScript map;
        public List<Ressources.Ressources> ressources;
        public List<Building.Building> availableBuildings;
        public List<Army.Army> availableArmy;
        public List<Technology.Technology> listTechno;
        public List<City> citiesOwn;
        public Network_global Network;
        public string turnInfo;

        public void Start()
        {
            Initiate();
            lobbby = FindObjectOfType<LobbyInfos>();
            map.Generate(lobbby.Seed);
            Network = FindObjectOfType<Network_global>();
            
        }

        public void AddInfos(IdAction id, string str)
        {
            turnInfo += id + ":" + str;
        }

        public void Win()
        {
            Network.SendString("trop fort!!!",IdMsg.winGame);
        }
        public void AffichageWin()
        {
            Text won=Instantiate(Won);
            allcities citi = FindObjectOfType<allcities>();
            won.transform.SetParent(citi.transform);
            won.transform.localScale = new Vector3(1, 1, 1);
            won.transform.localPosition = new Vector3(0, 0, 0) ;
        }
        

        public void EndTurn()
        {
            if (citiesOwn.Count >= 8)
            {
                Win();
            }
            else
            {
                Network.SendString(turnInfo, IdMsg.endTurn);
            }
        }


        public void Initiate()
        {
            citiesOwn = new List<City>();
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
