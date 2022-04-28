using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Camera cam;
    private Vector3 drag;
    public float zoom, minsize, maxsize;

    float targetZoom;
    public SpriteRenderer mapRenderer;
    private float mapMinx, mapMaxx, mapMiny, mapMaxy;
    // Start is called before the first frame update
    void Awake()
    {
        mapMinx = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxx = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMiny = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxy = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.mouseScrollDelta.y!=0&&(cam.orthographicSize != 5 || cam.orthographicSize != 20))
    {
            float targetZoom = cam.orthographicSize -Input.mouseScrollDelta.y*zoom ;
            cam.orthographicSize = Mathf.Clamp(targetZoom, minsize, maxsize);
            cam.transform.position = Cameramov(cam.transform.position);
        }
        PanCamera();
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
   

    public void ZoomIn()
    {

        
    }
    public void Zoomout()
    {

        float newSize = cam.orthographicSize - zoom;
        cam.orthographicSize = Mathf.Clamp(newSize, minsize, maxsize);
        cam.transform.position = Cameramov(cam.transform.position);
    }

    private Vector3 Cameramov(Vector3 targetp) => new Vector3(Mathf.Clamp(targetp.x,
                                                                         mapMinx + (cam.orthographicSize * cam.aspect),
                                                                         mapMaxx - (cam.orthographicSize * cam.aspect))
                                                              , Mathf.Clamp(targetp.y,
                                                                           mapMiny + cam.orthographicSize,
                                                                           mapMaxy - cam.orthographicSize)
                                                              , targetp.z);
}
