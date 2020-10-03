using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MixButtom : MonoBehaviour, IPointerDownHandler
{
    public ButtonColor c1;
    public ButtonColor c2;
    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        img.color = Color.Lerp(c1.GetComponent<Image>().color, c2.GetComponent<Image>().color, .5f);
        SceneController.Instance.colorPalette.SetActive(false);
        Test.Instance.drawColor = img.color;
    }
    
}
