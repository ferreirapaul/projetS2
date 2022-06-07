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
    public GameObject ListB;
    public GameObject ListA;
    public GameObject ListAUnlocked;
    public GameObject ChildB;
    public GameObject ChildA;
    public GameObject ChildAUnlocked;

    public GameObject spawnhere;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    public GameObject spawn9;
    public GameObject spawn10;
    public GameObject spawn11;
    public GameObject spawn12;
    public GameObject spawn13;
    public GameObject spawn14;
    public GameObject spawn15;
    public GameObject spawn16;

    public UIdeplacement UIdeplacement;

    public Game.Game game;
    public InputField Production;
    public InputField Sciences;
    public InputField Or;
    public InputField Nourriture;
    public InputField Population;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Or.text = game.ressources[0].Value+" Gold";
        Nourriture.text = game.ressources[1].Value+" Food";
        Population.text = game.ressources[2].Value+" Po";
        Production.text = game.ressources[3].Value+" Pr";
        Sciences.text = game.ressources[4].Value+" Sc";
    }

    public void UnlockNewArmy()
    {
        GameObject arm = Instantiate(ChildAUnlocked);
        int index = game.availableArmy.Count;
        arm.name = index.ToString();

        GameObject texta = arm.transform.Find("Name").gameObject;
        TextMeshProUGUI whythis = texta.GetComponent<TextMeshProUGUI>();

        whythis.text = game.availableArmy[index-1].Name;
        texta = arm.transform.Find("Cost").gameObject;
        whythis = texta.GetComponent<TextMeshProUGUI>();
        whythis.text += game.availableArmy[index-1].cost;

        texta = arm.transform.Find("Buy").gameObject;
        Button whybutton = texta.GetComponent<Button>();

        arm.transform.parent = ListAUnlocked.transform;
        arm.transform.localScale = new Vector3(1, 1, 1);
        VerticalLayoutGroup listofarmy = ListAUnlocked.GetComponent<VerticalLayoutGroup>();
        arm.transform.localPosition = new Vector3(0, 0, 0);
        listofarmy.spacing = 0;


        RectTransform rect = ListAUnlocked.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160.74f, rect.sizeDelta.y + 13.355f);
        ListAUnlocked.transform.localPosition = new Vector3(ListAUnlocked.transform.localPosition.x, ListAUnlocked.transform.localPosition.y - 6.677f, 0);
        RectTransform rectparent = ListAUnlocked.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 14);
    }
    //the name of the game object will be their number(1st unit=>1)
    public void AddArmy(int index)
    {
        if (true)
        {
            GameObject arm = Instantiate(ChildA);
            arm.name = game.UnlockArmy.Count.ToString();
            
            GameObject texta = arm.transform.Find("Name").gameObject;
            TextMeshProUGUI whythis=texta.GetComponent<TextMeshProUGUI>();
            whythis.text = game.availableArmy[index].Name;


            arm.transform.parent = ListA.transform;
            arm.transform.localScale = new Vector3(1, 1, 1);
            VerticalLayoutGroup listofarmy = ListA.GetComponent<VerticalLayoutGroup>();
            arm.transform.localPosition = new Vector3(0,0,0);
            listofarmy.spacing = 0;
        

            RectTransform rect = ListA.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(160.74f, rect.sizeDelta.y+13.355f);
            ListA.transform.localPosition =new Vector3(ListA.transform.localPosition.x, ListA.transform.localPosition.y-6.677f, 0) ;
            RectTransform rectparent = ListA.transform.parent.gameObject.GetComponent<RectTransform>();
            rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 14);

            switch (whythis.text)
            {
                case "Archer":
                    arm = Instantiate(spawn1);
                    break;
                case "Belier":
                    arm = Instantiate(spawn2);
                    break;
                case "Canon":
                    arm = Instantiate(spawn3);
                    break;
                case "Catapult":
                    arm = Instantiate(spawn4);
                    break;
                case "Cavalier":
                    arm = Instantiate(spawn5);
                    break;
                case "Crossbowman":
                    arm = Instantiate(spawn6);
                    break;
                case "Hallebardeer":
                    arm = Instantiate(spawn7);
                    break;
                case "Hoplite":
                    arm = Instantiate(spawn8);
                    break;
                case "Hussard":
                    arm = Instantiate(spawn9);
                    break;
                case "Infantry":
                    arm = Instantiate(spawn10);
                    break;
                case "Knight":
                    arm = Instantiate(spawn11);
                    break;
                case "Pikeman":
                    arm = Instantiate(spawn12);
                    break;
                case "Missile Launcher":
                    arm = Instantiate(spawn13);
                    break;
                case "Musketeer":
                    arm = Instantiate(spawn14);
                    break;
                case "Sniper":
                    arm = Instantiate(spawn15);
                    break;
                default:
                    arm = Instantiate(spawn16);
                    break;
            }
            arm.transform.parent = spawnhere.transform;
            arm.transform.localScale = new Vector3(1, 1, 1);
            arm.transform.localPosition = new Vector3(UIdeplacement.citi.Item1, UIdeplacement.citi.Item2 -1, 2);
            Army.Army kratos = arm.GetComponent<Army.Army>();
            game.UnlockArmy.Add(kratos);

        }
        

    }
    public void LevUpA(int indexofdaone)
    {
        //Army.Army= game.LevUp
        GameObject arm = ListA.transform.Find(indexofdaone.ToString()).gameObject;
        //TODO change

    }
    public void DestroyArmy(int index)
    {
        Destroy(ListA.transform.Find(index.ToString()));
        for (int i = index; i < ListA.transform.childCount; i++)
        {
            ListA.transform.Find(i.ToString()).gameObject.name = i.ToString();
        }
        RectTransform rect = ListA.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160.74f, rect.sizeDelta.y - 13.355f);
        ListA.transform.localPosition = new Vector3(ListA.transform.localPosition.x, ListA.transform.localPosition.y + 6.677f, 0);
        RectTransform rectparent = ListA.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y - 14);
    }
    public void AddBuildings(int index)
    {
        GameObject build = Instantiate(ChildB);
        build.name = game.UnlockBuildings.Count.ToString();

        GameObject textb = build.transform.Find("Name").gameObject;
        TextMeshProUGUI whythis = textb.GetComponent<TextMeshProUGUI>();
        whythis.text = game.availableBuildings[index].Name;

        textb = build.transform.Find("Lv up").gameObject;
        Button whybutton = textb.GetComponent<Button>();
        whybutton.onClick.AddListener(delegate { game.UnlockBuildings[index].LevelUp(); });

        build.transform.parent = ListB.transform;
        build.transform.localScale = new Vector3(1, 1, 1);
        VerticalLayoutGroup listofarmy = ListA.GetComponent<VerticalLayoutGroup>();
        build.transform.localPosition = new Vector3(0, 0, 0);
        listofarmy.spacing = 0;

        RectTransform rect = ListB.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160.74f, rect.sizeDelta.y + 13.355f);
        ListB.transform.localPosition = new Vector3(ListB.transform.localPosition.x, ListB.transform.localPosition.y - 6.677f, 0);
        RectTransform rectparent = ListB.transform.parent.gameObject.GetComponent<RectTransform>();
        rectparent.sizeDelta = new Vector2(0, rectparent.sizeDelta.y + 14);
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
        Panelbuildings.SetActive(true);
        Panelarmy.SetActive(false);
        Panelsciences.SetActive(false);
    }
    public void ChooseTechno()
    {
        Panelbuildings.SetActive(false);
        Panelarmy.SetActive(false);
        Panelsciences.SetActive(true);
    }
    public void ChooseArmy()
    {
        Panelbuildings.SetActive(false);
        Panelarmy.SetActive(true);
        Panelsciences.SetActive(false);
    }
}
