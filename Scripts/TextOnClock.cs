using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnClock : MonoBehaviour
{
    public Canvas messageCanvas;
    public float lowerBound;
    public float upperBound;
    public float interval;
    
    private float textDuration;
    public float textDurationTime = 3f;

    void Start()
    {
        interval = Random.Range(lowerBound, upperBound);
        messageCanvas.enabled = false;
        
    }

    void Update()
    {
        if (textDuration > 0)
        {
            textDuration -= Time.deltaTime;
            TurnOnMessage();

        } else if (textDuration <= 0)
        {

            if (interval > 0)
            {
                interval -= Time.deltaTime;
            }
            else
            {
                interval = Random.Range(lowerBound, upperBound);
                textDuration = textDurationTime;
                
            }

            TurnOffMessage();
           
        }

          
    }
    // Update is called once per frame


    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }


    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
}
