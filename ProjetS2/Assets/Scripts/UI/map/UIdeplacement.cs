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

    public Toggle mousedrag;
    public float speed = 1f;
    public float ClickDuration = 0.2f;
    bool clicking = false;
    float totalDownTime = 0;
    public allcities allcities;
    // Start is called before the first frame update
    void Start()
    {
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
        
            if (allcities.Panelville.activeSelf==false&&Input.mouseScrollDelta.y != 0 && (cam.orthographicSize != 5 || cam.orthographicSize != 20))
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

            if (mousedrag.isOn)
            {
                if (Input.GetMouseButtonDown(0))
                {
                     totalDownTime = 0;
                     clicking = true;
                      drag = cam.ScreenToWorldPoint(Input.mousePosition);
                }

                if (clicking && Input.GetMouseButton(0))
                {
                   totalDownTime += Time.deltaTime;

                     if (totalDownTime >= ClickDuration)
                     {
                       
                        Vector3 diff = drag - cam.ScreenToWorldPoint(Input.mousePosition);
                        cam.transform.position = Cameramov(cam.transform.position + diff);
                      }
                }
            }
        

    }



    public void verify(InputField input)
    {

        if (input.text.Length == 1)
        {
            if ((input.text[0] > 'a' && input.text[0] < 'z') || (input.text[0] > 'A' && input.text[0] < 'Z'))
            {
                //input.text = input.text[0].ToString();
            }
            else
            {
                input.text = "?";
            }
        }
        else
        {

            input.text = "?";
        }
        int i = 0;
        if (input == left)
        {
            i = 1;
        }
        if (input == backward)
        {
            i = 2;
        }
        if (input == right)
        {
            i = 3;
        }
        zqsd[i] = input.text;
        print(zqsd);
        print(zqsd[i]);

    }

    private Vector3 Cameramov(Vector3 targetp) => new Vector3(Mathf.Clamp(targetp.x,
                                                                         mapMinx + (cam.orthographicSize * cam.aspect),
                                                                         mapMaxx - (cam.orthographicSize * cam.aspect))
                                                              , Mathf.Clamp(targetp.y,
                                                                           mapMiny + cam.orthographicSize,
                                                                           mapMaxy - cam.orthographicSize)
                                                              , targetp.z);
}
