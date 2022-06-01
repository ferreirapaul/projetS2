using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Technology;
using TMPro;

public class TechnologyList : MonoBehaviour
{
    public GameObject ListS;
    public GameObject ChildS;
    public List<Technology.Technology> ancienttimes;
    public List<Technology.Technology> contemporary;
    public List<Technology.Technology> MiddleAge;
    public List<Technology.Technology> Reborn;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddTechno()
    {
        (string, string) both = (Reborn[index].name, Reborn[index].description);
        if(ancienttimes.Count==0)
        {
            both = (ancienttimes[index].name, ancienttimes[index].description);
        }
        else if (MiddleAge.Count==0)
        {
            both = (MiddleAge[index].name, MiddleAge[index].description);
        }
        else if (contemporary.Count == 0)
        {
            both = (contemporary[index].name, contemporary[index].description);
        }
        

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


       /* RectTransform rect = ListS.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160.74f, rect.sizeDelta.y + 13.355f);
        ListA.transform.localPosition = new Vector3(ListS.transform.localPosition.x, ListS.transform.localPosition.y - 6.677f, 0);
        RectTransform rectparent = ListS.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 14);*/
    }

}
