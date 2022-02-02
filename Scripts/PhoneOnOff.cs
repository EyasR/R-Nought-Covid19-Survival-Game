using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneOnOff : MonoBehaviour
{
    bool isPhoneOn;
    public Canvas messageCanvas;
    
    public float duration;
    public float setDuration;
    bool hasTriggered;
    
 


    void Start()
    {
        messageCanvas.enabled = false;
        isPhoneOn = false;  
        duration = setDuration;
        hasTriggered = false;
}

    // Update is called once per frame
    void Update()
    {
        if (hasTriggered)
        {
            duration -= Time.deltaTime;
        }


        if (duration <= 0)
        {
            messageCanvas.enabled = false;
            isPhoneOn = false;
            Destroy(this.gameObject);
        }


       if (Input.GetKeyDown(KeyCode.Return) && hasTriggered )
        {
            duration = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            messageCanvas.enabled = true;
            isPhoneOn = true;
            hasTriggered = true;
        }
    }
}
