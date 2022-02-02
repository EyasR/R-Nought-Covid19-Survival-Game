using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnTriggerOnce : MonoBehaviour
{
    public Canvas messageCanvas;
    public bool hasTriggered;
    public float duration;
    public float setDuration;

    void Start()
    {
        messageCanvas.enabled = false;
        hasTriggered = false; 
    }

    void update()
    {
        if (hasTriggered)
        {
            duration -= Time.deltaTime;
        }


        if (duration <= 0)
        {
            duration = setDuration;
            TurnOffMessage();
            hasTriggered = false;
        }

    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !hasTriggered)
        {
            hasTriggered = true;
            TurnOnMessage();
        }
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
}
