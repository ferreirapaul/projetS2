using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Technology;
using TMPro;
using Game;

public class TechnologyList : MonoBehaviour
{
    public GameObject ListS;
    public GameObject ChildS;
    public Game.Game game;
    public GameObject ListSAvailable;
    public GameObject ChildSAvailable;

    public void Start()
    {
        
    }

    
    public void AddTechno(int index)
    {
        (string, string) both = (game.listTechno[index].name, game.listTechno[index].description);
        Debug.Log(game.availableArmy.Count);
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
        rect.sizeDelta = new Vector2(532, rect.sizeDelta.y - 31);
        ListSAvailable.transform.localPosition = new Vector3(ListSAvailable.transform.localPosition.x, ListSAvailable.transform.localPosition.y + 15.5f, 0);
        RectTransform rectparent = ListSAvailable.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y - 31);
    }
    public void Dumber(string sciences)
    {
        string[] fichtre = sciences.Split('x');
        if (game.ressources[4].Value - int.Parse(fichtre[0])>0)
        {
            game.ressources[4].Value -= int.Parse(fichtre[0]);
            AddTechno(int.Parse(fichtre[1]));
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
