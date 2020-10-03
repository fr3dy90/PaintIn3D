using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTexture : MonoBehaviour
{
    public Texture2D tex;

    private void Start()
    {
        ReadTex();
    }

    void ReadTex()
    {
        for (int j = 0; j < tex.height; j++)
            {
                Debug.Log(tex.GetPixel(1024, j));
            }
    }
}
