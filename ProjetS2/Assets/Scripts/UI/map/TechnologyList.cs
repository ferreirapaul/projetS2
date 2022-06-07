using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Technology;
using TMPro;
using Game;
using Army;

public class TechnologyList : MonoBehaviour
{
    public GameObject ListS;
    public GameObject ChildS;
    public Game.Game game;
    public GameObject ListSAvailable;
    public GameObject ChildSAvailable;
    public allcities allcities;

    public void DysplayNewEra(int era)
    {
        for (int i = era*8; i < (era+1)*8; i++)
        {
            ListSAvailable.transform.Find(i.ToString()).gameObject.SetActive(true);
        }
    }
    
    public void AddTechno(int index)
    {
        game.UnlockTechnologies.Add(game.listTechno[index]);
        Debug.Log(index);
        /*bool army = false;
        Army.Army po = new Army.Hoplite();
        Debug.Log(po);
        switch (index)
        {
            case 1:
                army = true;
                po = new Army.Hoplite();
                break;
            case 2:
                po = new Army.Archer();
                break;
            case 3:
                po = new Army.Belier();
                break;
            case 4:
                po = new Army.Cavalier();
                break;
            case 8:
                po = new Army.Catapult();
                break;
            case 9:
                po = new Army.Crossbowman();
                break;
            case 11:
                po = new Army.Knight();
                break;
            case 13:
                po = new Army.Pike();
                break;
            case 16:
                po = new Army.Canon();
                break;
            case 17:
                po = new Army.Hallebardeer();
                break;
            case 18:
                po = new Army.Hussards();
                break;
            case 20:
                po = new Army.Musketeer();
                break;
            case 27:
                po = new Army.Infantry();
                break;
            case 28:
                po = new Army.MissileLauncher();
                break;
            case 30:
                po = new Army.Sniper();
                break;
            case 31:
                po = new Army.Tank();
                break;

            default:
                break;
        }
        Debug.Log(po);
        if (army)
        {
            game.availableArmy.Add(Army.Army.);
            allcities.UnlockNewArmy();
        }*/
        (string, string) both = (game.listTechno[index].name, game.listTechno[index].description);
            GameObject tech = Instantiate(ChildS);
            GameObject texts = tech.transform.Find("Name").gameObject;
            TextMeshProUGUI whythis = texts.GetComponent<TextMeshProUGUI>();
            whythis.text = both.Item1;
            texts = tech.transform.Find("Description").gameObject;
            whythis = texts.GetComponent<TextMeshProUGUI>();
            whythis.text = both.Item2;

            tech.transform.SetParent(ListS.transform);
            tech.transform.localScale = new Vector3(1, 1, 1);
            RectTransform rect = ListS.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(243.111f, rect.sizeDelta.y + 31);
            ListS.transform.localPosition = new Vector3(ListS.transform.localPosition.x, ListS.transform.localPosition.y - 15.5f, 0);
            RectTransform rectparent = ListS.transform.parent.gameObject.GetComponent<RectTransform>();
            rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 31);
            tech.transform.localPosition = new Vector3(tech.transform.localPosition.x, tech.transform.localPosition.y, 0);
            DestroyTechnoA(index);
    }
    public void DestroyTechnoA(int index)
    {
        GameObject himofficier = ListSAvailable.transform.Find(index.ToString()).gameObject;
        Destroy(himofficier);
        RectTransform rect = ListSAvailable.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(512, rect.sizeDelta.y - 31);
        ListSAvailable.transform.localPosition = new Vector3(ListSAvailable.transform.localPosition.x, ListSAvailable.transform.localPosition.y + 15.5f, 0);
        RectTransform rectparent = ListSAvailable.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y - 31);
    }
    public void Dumber(string sciences)
    {
        string[] fichtre = sciences.Split('x');
        if (game.listTechno.Count > int.Parse(fichtre[1]))
        {
            
            if (game.ressources[4].Value - int.Parse(fichtre[0]) >= 0)
            {
                game.ressources[4].Value -= int.Parse(fichtre[0]);
                AddTechno(int.Parse(fichtre[1]));
            }
        }
    }
    /*
    public void AddTechnoA(int index)
    {
        (string, string) both = (game.listTechno[index].name, game.listTechno[index].description);

        GameObject tech = Instantiate(ChildSAvailable);
        GameObject texts = tech.transform.Find("Name").gameObject;
        TextMeshProUGUI whythis = texts.GetComponent<TextMeshProUGUI>();
        whythis.text = both.Item1;
        texts = tech.transform.Find("Description").gameObject;
        whythis = texts.GetComponent<TextMeshProUGUI>();
        whythis.text = both.Item2;
        texts = tech.transform.Find("Cost").gameObject;
        whythis = texts.GetComponent<TextMeshProUGUI>();
        whythis.text += game.listTechno[index].Coast;

        Button button= tech.transform.Find("Buy").gameObject.GetComponent<Button>();
        Debug.Log(button);
        int x = new int();
        x = index;
        //button.GetComponent<Button>().onClick.AddListener(delegate { AddTechno(x); });

        tech.transform.SetParent(ListSAvailable.transform);
        tech.transform.localScale = new Vector3(1, 1, 1);


        RectTransform rect = ListSAvailable.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(532, rect.sizeDelta.y + 31);
        ListSAvailable.transform.localPosition = new Vector3(ListSAvailable.transform.localPosition.x, ListSAvailable.transform.localPosition.y - 15.5f, 0);
        RectTransform rectparent = ListSAvailable.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 31);
    }*/
}
