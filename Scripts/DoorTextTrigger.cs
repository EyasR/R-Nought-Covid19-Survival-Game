using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTextTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas messageCanvas;
    public GameObject playerReference;

    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        messageCanvas.enabled = false;
    }

     void update()
    {
       this.transform.position = playerReference.transform.position ;
    }
    // Update is called once per frame
    void OnTriggerStay2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Door")
        {
            Debug.Log("collision occured");
            TurnOnMessage();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Door")
        {
            Debug.Log("collision occured");
            TurnOnMessage();
        }
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
}
