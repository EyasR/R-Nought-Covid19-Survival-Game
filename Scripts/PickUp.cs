using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerReference;
    public Canvas messageCanvas;
    public string itemName;

    void Start()
    {
        messageCanvas.enabled = false;
        playerReference = GameObject.Find("AnimatedPlayer");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            PlayerBehavior playerScript = playerReference.GetComponent<PlayerBehavior>();
            if( playerScript.hasFaceMask && itemName == "facemask")
            {
                messageCanvas.enabled = true;
                transform.position = new Vector3(-200f,-200f,0);   
                //Destroy(this.gameObject);
            }
            if (playerScript.hasGloves && itemName == "gloves")
            {
                messageCanvas.enabled = true;
                transform.position = new Vector3(-200f, -200f, 0);
            }
        }
    }
}
