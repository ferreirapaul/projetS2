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
    public GameObject NameA;
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
                DisplayInformations(Name,)
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
   
    public void DisplayInformations(string name,List<cities> buildings)
    {
        Panelbuildings.SetActive(true);
        Name.text = name;
        DisplayList(0);

    }
    
    public void DisplayArmy(string name, List<army> army)
    {
        Panelarmy.SetActive(true);
        DisplayList(1);
    }

    public void DisplaySciences(string name, List<army> army)
    {
        Panelsciences.SetActive(true);
        DisplayList(2);
    }
    */
    public void AddArmy(int numberofarmy,string name)
    {
        
        GameObject arm = Instantiate(ChildA);
        GameObject texta = arm.transform.Find("Name").gameObject;
        Debug.Log(texta);
        TextMeshProUGUI whythis=texta.GetComponent<TextMeshProUGUI>();
        whythis.text = name;
        arm.transform.parent = ListA.transform;
        arm.transform.localScale = new Vector3(1, 1, 1);
        VerticalLayoutGroup listofarmy = ListA.GetComponent<VerticalLayoutGroup>();
        listofarmy.spacing = numberofarmy*3-105;
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
