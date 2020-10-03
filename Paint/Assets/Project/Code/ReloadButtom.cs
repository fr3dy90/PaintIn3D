using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReloadButtom : MonoBehaviour, IPointerDownHandler
{
    public int index;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(index);
    }
}
