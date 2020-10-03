using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReadPixelColor : MonoBehaviour, IPointerDownHandler
{
    public Image img;
    public GameObject m_Parent;
    
    public Slider r;
    public Slider g;
    public Slider b;
    

    private void Start()
    {
        SetColor();
        r.onValueChanged.AddListener(delegate{ SetColor(); });
        g.onValueChanged.AddListener(delegate{ SetColor(); });
        b.onValueChanged.AddListener(delegate{ SetColor(); });
        m_Parent.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneController.Instance.SetColor(img.color);
        m_Parent.gameObject.SetActive(false);
    }
    
    public void SetColor()
    {
        img.color = new Color(r.value, g.value, b.value);   
    }

    private void OnEnable()
    {
        SetColor();
    }
    /*private Vector2 localCursor;
    private RectTransform _rectTransform;
    public Texture2D tex;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var pos1 = eventData.position;
        if(!RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, pos1, null, out localCursor))
            return;
        int xpos = (int) localCursor.x;
        int ypos = (int) localCursor.y;

        if (xpos < 0) xpos = xpos + (int)_rectTransform.rect.width / 2;
        else xpos += (int)_rectTransform.rect.width / 2;
 
        if (ypos > 0) ypos = ypos + (int)_rectTransform.rect.height / 2;
        else ypos += (int)_rectTransform.rect.height / 2;
        
        Debug.Log("Correct Cursor Pos "+ xpos+" "+ypos);
        Color c = tex.GetPixel(xpos * 4, ypos * 4);
        SceneController.Instance.SetColor(c);
        gameObject.SetActive(false);
        
    }*/
    
}