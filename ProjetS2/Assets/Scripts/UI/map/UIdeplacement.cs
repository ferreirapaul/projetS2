using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIdeplacement : MonoBehaviour
{
    public Camera cam;
    private Vector3 drag;
    public float zoom, minsize, maxsize;

    float targetZoom;
    public SpriteRenderer mapRenderer;
    private float mapMinx, mapMaxx, mapMiny, mapMaxy;
    public InputField forward;
    public InputField backward;
    public InputField left;
    public InputField right;
    private List<string> zqsd;

    public (int, int) citi;
    public Toggle mousedrag;
    public float speed = 1f;
    public float ClickDuration = 0.2f;
    bool clicking = false;
    float totalDownTime = 0;
    public GameObject Panevile;
    public GenMapScript Genmap;
    public Game.Game game;
    public allcities allcities;
    private (bool,int) armychoose = (false,0);

    private bool startOfGame;
    // Start is called before the first frame update
    void Start()
    {
        startOfGame = true;
        mapMinx = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxx = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMiny = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxy = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;

        zqsd = new List<string>();
        zqsd.Add("z");
        zqsd.Add("q");
        zqsd.Add("s");
        zqsd.Add("d");
        cam.orthographicSize = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (Panevile.activeSelf == false)
        {
            if (Input.mouseScrollDelta.y != 0 && (cam.orthographicSize != 5 || cam.orthographicSize != 20))
            {
                float targetZoom = cam.orthographicSize - Input.mouseScrollDelta.y * zoom;
                cam.orthographicSize = Mathf.Clamp(targetZoom, minsize, maxsize);
                cam.transform.position = Cameramov(cam.transform.position);
            }
            if (Input.GetKey(zqsd[0]))
            {
                Vector3 diff = new Vector3(0f, speed, 0f);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }

            if (Input.GetKey(zqsd[1]))
            {
                Vector3 diff = new Vector3(-speed, 0, 0);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }
            if (Input.GetKey(zqsd[2]))
            {
                Vector3 diff = new Vector3(0, -speed, 0);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }
            if (Input.GetKey(zqsd[3]))
            {
                Vector3 diff = new Vector3(speed, 0, 0);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 diff = new Vector3(-speed, 0, 0);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 diff = new Vector3(0, -speed, 0);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {

                Vector3 diff = new Vector3(0f, speed, 0f);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 diff = new Vector3(speed, 0, 0);
                cam.transform.position = Cameramov(cam.transform.position + diff);
            }

            if (Input.GetMouseButtonDown(0))
            {
                     totalDownTime = 0;
                     clicking = true;
                     drag = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (clicking && Input.GetMouseButton(0))
            {
                totalDownTime += Time.deltaTime;

                if (totalDownTime >= ClickDuration && mousedrag.isOn)
                {
                    Vector3 diff = drag - cam.ScreenToWorldPoint(Input.mousePosition);
                    cam.transform.position = Cameramov(cam.transform.position + diff);
                }
                else
                {
                    
                    Map map = Genmap.map;
                    Vector3 mickey = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (armychoose.Item1)
                    {
                        Army.Army arm = game.UnlockArmy[armychoose.Item2];
                        arm.movement((int)arm.gameObject.transform.localPosition.x, (int)arm.gameObject.transform.localPosition.y, (int)mickey[0], (int)mickey[1], armychoose.Item2);
                        

                    }
                    List<(int, int)> citipos = new List<(int, int)> { ((int)mickey[0], (int)mickey[1]+1), ((int)mickey[0]-1, (int)mickey[1]+1), ((int)mickey[0], (int)mickey[1]), ((int)mickey[0]-1, (int)mickey[1]) };
                    int i = 0;
                    bool foundciti = false;
                    bool foundarmy = false;
                    Debug.Log("citiesOwn.count =" + game.citiesOwn.Count);
                    if (startOfGame)
                    {
                        game.citiesOwn = map.startingCities;
                    }
                    while (i < game.citiesOwn.Count && !foundciti && !foundarmy)
                    {
                        GameObject citi = game.citiesOwn[i].gameObject;
                        foundciti = citi.transform.localPosition.x == citipos[0].Item1 && citi.transform.localPosition.y == citipos[0].Item2;

                        i++;
                    }
                    Debug.Log("foundciti = " + foundciti);
                    int index = 0;
                    while (!foundciti && index < game.UnlockArmy.Count && !foundarmy)
                    {
                        int ind = 0;
                        while (ind<4 && !foundciti)
                        { 
                            foundarmy= game.UnlockArmy[index].gameObject.transform.localPosition[0] == citipos[index].Item1 && game.UnlockArmy[i].gameObject.transform.localPosition[1] == citipos[index].Item2 ;

                            ind++;
                        }
                        index++;
                    }
                    if (foundciti)
                    {
                        citi=citipos[i];
                        Panevile.SetActive(true);
                        
                        if (startOfGame)
                        {
                            foreach (City city in map.ListOfCities)
                            {
                                Debug.Log("city.posX = " + city.posX);
                                Debug.Log("city.posY = " + city.posY);
                                Debug.Log("citi.Item1 = " + citi.Item1);
                                Debug.Log("citi.Item2 = " + citi.Item2);
                                if (city.posX == citi.Item1 && city.posY == citi.Item2)
                                {
                                    startOfGame = false;
                                    map.SelectCity(city);
                                }
                            }
                        }
                    }
                    if (foundarmy)
                    {
                        armychoose.Item1 = game.UnlockArmy[index].IsEnemy;
                        armychoose.Item2 = index;
                    }
                }
            }
        }
        

    }

    private Vector3 Cameramov(Vector3 targetp) => new Vector3(Mathf.Clamp(targetp.x,
                                                                         mapMinx + (cam.orthographicSize * cam.aspect),
                                                                         mapMaxx - (cam.orthographicSize * cam.aspect))
                                                              , Mathf.Clamp(targetp.y,
                                                                           mapMiny + cam.orthographicSize,
                                                                           mapMaxy - cam.orthographicSize)
                                                              , targetp.z);
}
