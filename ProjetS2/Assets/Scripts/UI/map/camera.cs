using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speedmov = 1f;
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
            transform.position = new Vector3(transform.position.x + speedmov, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow)&& Camera.main.transform.position.x>35f -11+targetZoom)
        {
            transform.position = new Vector3(transform.position.x - speedmov, transform.position.y, transform.position.z);
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speedzoom * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speedzoom * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speedzoom * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, speedzoom * Time.deltaTime, 0));
        }
    }
}
