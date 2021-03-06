using System;
using System.Collections;
using System.Collections.Generic;
using Ressources;
using Army;
using Network;
using Technology;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public LobbyInfos lobbby;
        public GenMapScript map;
        public InformationBox box;
        public List<Ressources.Ressources> ressources;
        public List<Building.Building> availableBuildings;
        public List<Army.Army> availableArmy;
        public List<Technology.Technology> listTechno;
        public List<City> citiesOwn;
        public List<City> citiesHidden;
        public Network_global Network;
        public string turnInfo;
        private List<Tuple<IdAction, string>> actions;
        public List<Technology.Technology> UnlockTechnologies;
        public List<Building.Building> UnlockBuildings;
        public List<Army.Army> UnlockArmy;
        public int era = 0;
        public TechnologyList TechnologyList;
        public bool youTurnInfo = false;
        public bool youTurn;

        public void Start()
        {
            lobbby = FindObjectOfType<LobbyInfos>();
            Network = FindObjectOfType<Network_global>();
            map.Generate(lobbby.Seed);
            actions = new List<Tuple<IdAction, string>>();
            Initiate();
        }

        public void Update()
        {
            if (actions.Count > 0)
            {
                foreach (Tuple<IdAction, string> i in actions)
                {
                    MakeAction(i.Item1, i.Item2);
                }
            }
            if (youTurnInfo)
            {
                box.ChangeText("It's you turn : make you actions and then click on end turn");
                youTurn = true;
                youTurnInfo = false;
            }
        }

        public void AddInfos(IdAction id, string str)
        {
            turnInfo += id + ":" + str + ";";
        }

        public void Win()
        {
            Network.SendString("trop fort!!!",IdMsg.winGame);
        }
        

        public void EndTurn()
        {
            if (youTurn)
            {
                if (citiesOwn.Count >= 8)
                {
                    Win();
                }
                else
                {
                    if (this.listTechno.Count == 0)
                    {
                        EraChange();
                    }
                    foreach (Technology.Technology i in this.UnlockTechnologies)
                    {
                        i.Effects();
                    }

                    foreach (Army.Army i in this.UnlockArmy)
                    {
                        this.ressources[0].Value -= i.coastEachTurn;
                    }

                    foreach (City i in this.citiesOwn)
                    {
                        i.MakeTurn();
                    }
                    Network.SendString(turnInfo, IdMsg.endTurn);
                }
            }
            else
            {
                box.ChangeText("It's not your turn !");
            }
        }

        public void MakeAction(IdAction action, string val)
        {
            bool go;
            int i;
            switch (action)
            {
                case IdAction.eraChange:
                    box.ChangeText(val);
                    break;
                case IdAction.healthChange:
                    go = true;
                    i = 0;
                    while (i < this.citiesOwn.Count && go)
                    {
                        if (citiesOwn[i].ID == Int32.Parse(val))
                        {
                            go = false;
                            citiesOwn[i].Health += 1000;
                        }

                        i++;
                    }
                    break;
                case IdAction.UnlockCommunism:
                    string temp = "";
                    foreach (char c in val)
                    {
                        if (c == '-')
                        {
                            go = true;
                            i = 0;
                            while (i < map.map.ListOfCities.Count && go)
                            {
                                if (map.map.ListOfCities[i].ID == Int32.Parse(temp))
                                {
                                    go = false;
                                    citiesHidden.Add(map.map.ListOfCities[i]);
                                }

                                i++;
                            }
                        }
                    }
                    break;
            }
        }

        public void DecryptTurn(List<string> value)
        {
            IdAction id = IdAction.eraChange;
            string temp = "";
            foreach (string i in value)
            {
                temp = "";
                foreach (char j in i)
                {
                    if (j == ':')
                    {
                        id = (IdAction) Int32.Parse(temp);
                        temp = "";
                    }
                    else
                    {
                        temp += j;
                    }
                }

                actions.Add(new Tuple<IdAction, string>(id,temp));
            }
            
        }

        public void EraChange()
        {
            era++;
            switch (era)
            {
                case 1:
                    listTechno.Add(new Technology.Catapult(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Crossbow(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Feudalism(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Technology.Knight(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Mill(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Technology.Pike(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Religion(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Wall(ressources,availableBuildings,availableArmy,this));
                    break;
                case 2:
                    listTechno.Add(new Cannon(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Halberdier(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Hussar(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Lumieres(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Musketeers(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Napoleon(ressources,availableBuildings,availableArmy,this));
                    listTechno.Add(new Revolution(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new SteamMachine(ressources,availableBuildings,availableArmy));
                    break;
                case 3:
                    listTechno.Add(new Computer(ressources,availableBuildings,availableArmy,this));
                    listTechno.Add(new Comunism(ressources,availableBuildings,availableArmy,map, this));
                    listTechno.Add(new Globalization(ressources,availableBuildings,availableArmy,map));
                    listTechno.Add(new Technology.Infantry(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Missiles(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Oil(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Technology.Sniper(ressources,availableBuildings,availableArmy));
                    listTechno.Add(new Technology.Tank(ressources,availableBuildings,availableArmy));
                    break;
                default:
                    break;
                    
            }

            foreach (Technology.Technology i in this.UnlockTechnologies)
            {
                i.upgradePeriod();
            }
            TechnologyList.DysplayNewEra(era);
            AddInfos(IdAction.eraChange,this.lobbby.Name +" Change of era");
        }


        public void Initiate()
        {
            UnlockTechnologies = new List<Technology.Technology>();
            UnlockArmy = new List<Army.Army>();
            UnlockBuildings = new List<Building.Building>();
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
            listTechno.Add(new ArmyC(ressources,availableBuildings,availableArmy,this));
            listTechno.Add(new Bow(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Ebeniste(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Equitation(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Forge(ressources,availableBuildings,availableArmy));
            listTechno.Add(new Market(ressources,availableBuildings,availableArmy));
            listTechno.Add(new School(ressources,availableBuildings,availableArmy));
            
        }

        
    }
}
