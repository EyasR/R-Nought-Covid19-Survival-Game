using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnTrigger : MonoBehaviour
{
    public Canvas messageCanvas;
    public float duration;
    public float setDuration;
    public bool hasTriggered;
    private bool hasExited;

    void Start()
    {
        messageCanvas.enabled = false;
        duration = setDuration;
        hasTriggered = false;
        hasExited = false;
    }

    void Update()
    {
        if (hasTriggered && hasExited)
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
        hasExited = false;
        if (col.gameObject.tag == "Player")
        {
            TurnOnMessage();
            hasTriggered = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasExited = true;
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
}
