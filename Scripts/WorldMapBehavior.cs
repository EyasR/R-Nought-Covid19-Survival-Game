using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas messageCanvas;
    public bool isOpen;

    // Update is called once per frame
    void start()
    {
        messageCanvas.enabled = false;
        isOpen = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isOpen)
        {
            messageCanvas.enabled = true;
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.M) && isOpen)
        {
            messageCanvas.enabled = false;
            isOpen = false;

        }
    }

}
