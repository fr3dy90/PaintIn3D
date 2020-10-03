using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (SceneController.Instance.b_Color != this)
        {
            SceneController.Instance.b_Color = this;
        }
        else
        {
            SceneController.Instance.SetButton(this);
        }
    }
}
