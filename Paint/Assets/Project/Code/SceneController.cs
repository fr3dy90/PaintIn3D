using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public GameObject colorPalette;
    public ButtonColor b_Color;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        colorPalette.SetActive(false);
    }
    
    public void SetButton(ButtonColor bc)
    {
        b_Color = bc;
        colorPalette.SetActive(true);
    }

    public void SetColor(Color c)
    {
        b_Color.GetComponent<Image>().color = c;
    }
}
