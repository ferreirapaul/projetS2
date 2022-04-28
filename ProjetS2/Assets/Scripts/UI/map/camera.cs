using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    /*public float speedmov = 1f;
    public Camera cam;
    private float maxZoom = 5;
    private float minZoom = 20;
    private float sensitivity = 1;
    private float speedzoom = 30;
    float targetZoom;
    public void FixedUpdate()
    {
        //movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cam.transform.position = Cameramov(cam.transform.position + new Vector3(cam.transform.position.x + speedmov, cam.transform.position.y, cam.transform.position.z));
        }
        if (Input.GetKey(KeyCode.LeftArrow)&& Camera.main.transform.position.x>35f -11+targetZoom)
        {
            cam.transform.position = Cameramov(cam.transform.position + new Vector3(cam.transform.position.x + speedmov, cam.transform.position.y, cam.transform.position.z));
        }
        if (Input.GetKey(KeyCode.DownArrow) && Camera.main.transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speedmov, transform.position.z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
           
            transform.position = new Vector3(transform.position.x, transform.position.y + speedmov, transform.position.z);
        } 

        //zoom
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speedzoom * Time.deltaTime);
        cam.orthographicSize = newSize;
        float newSize = cam.orthographicSize + zoom;
        cam.orthographicSize = Mathf.Clamp(newSize, minsize, maxsize);
        cam.transform.position = Cameramov(cam.transform.position);


        
    }protected Vector3 Cameramov(Vector3 targetp) => new Vector3(Mathf.Clamp(targetp.x,
                                                                         mapMinx + (cam.orthographicSize * cam.aspect),
                                                                         mapMaxx - (cam.orthographicSize * cam.aspect))
                                                              , Mathf.Clamp(targetp.y,
                                                                           mapMiny + cam.orthographicSize,
                                                                           mapMaxy - cam.orthographicSize)
                                                              , targetp.z);*/
}
