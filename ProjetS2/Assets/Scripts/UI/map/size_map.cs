using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class size_map : MonoBehaviour
{
    public float X=160f;
    public float Y=160f;
    public SpriteRenderer spriteRenderer;
    public Camera cam;
    public RawImage minimap;
    public RenderTexture renderTexture;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer.transform.Translate(X / 2f -0.5f, Y / 2f -0.5f, 0);
        spriteRenderer.transform.localScale = new Vector3(X, Y, 0);

        cam.orthographicSize = X / 2f;
        cam.transform.position = new Vector3(Y/2f, X/2f, 0);


        float scalex = X / 10;
        float scaley = Y / 10;
        if (scalex!=scaley)
        {
            if (scalex > scaley)
            {
                scaley = 0;
                scalex -= scaley;
                while (scalex>10)
                {
                    scalex/= 10f;
                }
            }
            else
            {
                scalex = 0;
                scaley -= scalex;
                while (scaley > 10)
                {
                    scaley/= 10f;
                }
            }
        }
        else
        {
            scalex = 0f;
            scaley = 0f;
        }

        minimap.transform.localScale = new Vector3(10f+scalex, 10f+scaley, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

