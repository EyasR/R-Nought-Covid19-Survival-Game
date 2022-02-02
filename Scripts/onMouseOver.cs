using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public Canvas descriptionCanvas;

    private bool mouse_over = false;
    void Update()
    {
        if (mouse_over)
        {
            Debug.Log("Mouse Over");
        }
    }

    void start()
    {
        descriptionCanvas.enabled = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        descriptionCanvas.enabled = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        descriptionCanvas.enabled = false;
        Debug.Log("Mouse exit");
    }
}
