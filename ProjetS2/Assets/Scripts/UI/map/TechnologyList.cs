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
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < game.listTechno.Count; i++)
        {
            AddTechno(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddTechno(int index)
    {
        (string, string) both = (game.listTechno[index].name, game.listTechno[index].description);
        

        GameObject tech = Instantiate(ChildS);
        GameObject texts = tech.transform.Find("Name").gameObject;
        TextMeshProUGUI whythis = texts.GetComponent<TextMeshProUGUI>();
        whythis.text =both.Item1;
        texts = tech.transform.Find("Description").gameObject;
        whythis = texts.GetComponent<TextMeshProUGUI>();
        whythis.text = both.Item2;
        tech.transform.parent = ListS.transform;

        tech.transform.localScale = new Vector3(1, 1, 1);
        VerticalLayoutGroup listoftech = ListS.GetComponent<VerticalLayoutGroup>();
        tech.transform.localPosition = new Vector3(0, 0, 0);
        listoftech.spacing = 0;


        RectTransform rect = ListS.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(243.111f, rect.sizeDelta.y + 31);
        ListS.transform.localPosition = new Vector3(ListS.transform.localPosition.x, ListS.transform.localPosition.y - 15.5f, 0);
        RectTransform rectparent = ListS.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 31);
    }

}
