using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnTriggerAction : MonoBehaviour
{
    public Canvas messageCanvas;
    public float duration;
    public bool hasTriggered;
   

    void Start()
    {
        messageCanvas.enabled = false;
        duration = 5f;
        hasTriggered = false;

        
    }

    void Update()
    {
        if (hasTriggered)
        {
             duration -= Time.deltaTime;   
        }

   
        if(duration <= 0)
        {
            duration = 5f;
            TurnOffMessage();
            hasTriggered = false;
        }

    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }
    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            TurnOnMessage();
            hasTriggered = true;
        }
    }
}
