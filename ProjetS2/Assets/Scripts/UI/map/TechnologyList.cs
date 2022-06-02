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
    public GameObject ListSAvilable;
    public GameObject ChildSAvailable;
    // Start is called before the first frame update
    void Start()
    {
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
        tech.transform.SetParent(ListS.transform);

        tech.transform.localScale = new Vector3(1, 1, 1);


        RectTransform rect = ListS.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(243.111f, rect.sizeDelta.y + 31);
        ListS.transform.localPosition = new Vector3(ListS.transform.localPosition.x, ListS.transform.localPosition.y - 15.5f, 0);
        RectTransform rectparent = ListS.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 31);
    }

    public void DisplayAvailableTechno(int index)
    {

    }
}
