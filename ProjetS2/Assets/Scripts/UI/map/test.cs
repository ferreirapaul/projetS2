using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.mouseScrollDelta.y!=0 &&(cam.orthographicSize != 5 || cam.orthographicSize != 20))
    {
            float targetZoom = cam.orthographicSize -Input.mouseScrollDelta.y*zoom ;
            cam.orthographicSize = Mathf.Clamp(targetZoom, minsize, maxsize);
            cam.transform.position = Cameramov(cam.transform.position);
        }
        PanCamera();
        
       if (Input.GetKeyDown(zqsd[0]))
       {
            Vector3 diff = new Vector3(0, 1, 0);
            cam.transform.position = Cameramov(cam.transform.position + diff);
       }
        if (Input.GetKeyDown(zqsd[1]))
        {
            Vector3 diff = new Vector3(-1, 0, 0);
            cam.transform.position = Cameramov(cam.transform.position + diff);
        }
        if (Input.GetKeyDown(zqsd[2]))
        {
            Vector3 diff = new Vector3(0, -1, 0);
            cam.transform.position = Cameramov(cam.transform.position + diff);
        }
        if (Input.GetKeyDown(zqsd[3]))
        {
            Vector3 diff = new Vector3(1, 0, 0);
            cam.transform.position = Cameramov(cam.transform.position + diff);
        }

    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            drag = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 diff = drag - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = Cameramov(cam.transform.position + diff);
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
