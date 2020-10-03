using System;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public static Test Instance;
    public Camera cam;
    public float radius;
    public bool down;
    public Vector3 oldPosition;
    public float drawDist = 0.5f;
    public Color drawColor = Color.black;
    public Slider brushSize;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        brushSize.onValueChanged.AddListener(delegate { SetBrushSize(); });
    }

    void Update()
    {
        /*if(Input.GetButtonDown("Jump"))
        {
            MixColor();
        }*/
        
        if (!Input.GetMouseButton(0))
        {
            down = false;
            return;
        }

        if (down)
        {
            if (Vector3.Magnitude(oldPosition - Input.mousePosition) < drawDist)
                return;
        }

        down = true;
        oldPosition = Input.mousePosition;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null ||
            meshCollider == null)
            return;
        
        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        for (int j = 0; j < radius; j++)
        {
            Vector2 drawRadius = new Vector2(j / (float)tex.width, j / (float)tex.height);
            float alpha = 1 - j * 2.0f / radius;
            alpha = alpha < 0 ? 0 : alpha;
        
            for (int i = 0; i < 360; i++)
            {
                float angle = i * Mathf.PI / 180.0f;
                Vector2 v2 = new Vector2(Mathf.Cos(angle)*drawRadius.x, Mathf.Sin(angle)*drawRadius.y);
                Vector2 drawUV = pixelUV;
                drawUV.x += v2.x;
                drawUV.y += v2.y;
            
                drawUV.x *= tex.width;
                drawUV.y *= tex.height;
                Color pixelColor = tex.GetPixel((int) drawUV.x, (int) drawUV.y);
                pixelColor.r = alpha * drawColor.r + (1 - alpha) * pixelColor.r;
                pixelColor.g = alpha * drawColor.g + (1 - alpha) * pixelColor.g;
                pixelColor.b = alpha * drawColor.b + (1 - alpha) * pixelColor.b;
                tex.SetPixel((int) drawUV.x, (int) drawUV.y, pixelColor);
            }
        }
        
        tex.Apply();
    }

    public void SetBrushSize()
    {
        radius = brushSize.value;
    }
    /*public void MixColor()
    {
        float r1 = c1.r * c1.r;
        float r2 = c2.r * c2.r;
        float g1 = c1.g * c1.g;
        float g2 = c2.g * c2.g;
        float b1 = c1.b * c1.b;
        float b2 = c2.b * c2.b;

        float r = r1 + r2;
        float g = g1 + g2;
        float b = b1 + b2;

        r = r / 2f;
        g = g / 2f;
        b = b / 2f;

        r = Mathf.Sqrt(r);
        g = Mathf.Sqrt(g);
        b = Mathf.Sqrt(b);
        
        c3 = new Color(r,g,b);
        
        
     
     
     

        c3 = Color.Lerp(c1, c2, .5f);
    }*/
}