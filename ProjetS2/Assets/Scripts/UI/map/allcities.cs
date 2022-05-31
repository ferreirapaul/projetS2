using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class allcities : MonoBehaviour
{
    public GameObject Panelville;
    public GameObject Panelbuildings;
    public GameObject Panelsciences;
    public GameObject Panelarmy;
    public InputField Name;
    public GameObject ListB;
    public GameObject ListA;
    public GameObject ChildB;
    public GameObject ChildA;
    private int displaywhat = 0;
    // Start is called before the first frame update
    void Start()
    {
        Panelbuildings.SetActive(true);
        Panelarmy.SetActive(false);
        Panelsciences.SetActive(false);
        //Panelville.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*switch (displaywhat)
        {
            case 0:
                DisplayBuildings(Name,)
                break;
            case 1:
                DisplaySciences();
                break;
            default:
                DisplayArmy();
                break;
        }*/
    }
    /*
    public void DisplayList(int which)
    {
        
    }
   
    public void DisplayBuildings(string name,List<cities> buildings)
    {
        Panelbuildings.SetActive(true);
        Name.text = name;

    }
    
    public void DisplayArmy(string name, List<army> army)
    {
        Panelarmy.SetActive(true);
    }

    public void DisplaySciences(string name, List<army> army)
    {
        Panelsciences.SetActive(true);
    }
    */
    public void AddArmy(string name)
    {
        GameObject arm = Instantiate(ChildA);
        
        GameObject texta = arm.transform.Find("Name").gameObject;
        Debug.Log(texta);
        TextMeshProUGUI whythis=texta.GetComponent<TextMeshProUGUI>();
        whythis.text = name;
        arm.transform.parent = ListA.transform;
        arm.transform.localScale = new Vector3(1, 1, 1);
        VerticalLayoutGroup listofarmy = ListA.GetComponent<VerticalLayoutGroup>();
        arm.transform.localPosition = new Vector3(0,0,0);
        listofarmy.spacing = 0;
        

        RectTransform rect = ListA.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160.74f, rect.sizeDelta.y+13.355f);
        ListA.transform.localPosition =new Vector3(ListA.transform.localPosition.x, ListA.transform.localPosition.y-6.677f, 0) ;
        RectTransform rectparent = ListA.transform.parent.gameObject.GetComponent<RectTransform>();
        Debug.Log(rectparent);
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 14);
    }
    /*
     * -22.525
     * 
     * -22.202
     * 
     * */

    public void AddBuildings(string name)
    {
        GameObject build = Instantiate(ChildB);
        GameObject textb = build.transform.Find("Name").gameObject;
        TextMeshProUGUI whythis = textb.GetComponent<TextMeshProUGUI>();
        whythis.text = name;
        build.transform.parent = ListB.transform;
        build.transform.localScale = new Vector3(1, 1, 1);
        VerticalLayoutGroup listofbuildings = ListB.GetComponent<VerticalLayoutGroup>();
    }
    public void testAdd()
    {
        AddArmy("fuck");
    }
    public void DisplayInformations()
    {
        Panelville.SetActive(true);
    }
    public void HideInformations()
    {
        Panelville.SetActive(false);
    }
    public void ChooseBuildings()
    {
        displaywhat = 0;
        Panelbuildings.SetActive(true);
        Panelarmy.SetActive(false);
        Panelsciences.SetActive(false);
    }
    public void ChooseSciences()
    {
        displaywhat = 1;
        Panelbuildings.SetActive(false);
        Panelarmy.SetActive(false);
        Panelsciences.SetActive(true);
    }
    public void ChooseArmy()
    {
        displaywhat = 2;
        Panelbuildings.SetActive(false);
        Panelarmy.SetActive(true);
        Panelsciences.SetActive(false);
    }
}
