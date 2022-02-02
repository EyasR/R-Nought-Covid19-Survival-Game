using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealerScript : MonoBehaviour
{
    public Canvas messageCanvas;
    public PlayerBehavior playerReference;

    public float duration;
    public float setDuration;

    public float buyTimer;
    private const float buyInterval = .25f;

    public bool hasTriggered;
    public int cost;
    public string item;
    private bool inRange;

    void Start()
    {
        messageCanvas.enabled = false;
        duration = setDuration;
        hasTriggered = false;
        buyTimer = buyInterval;
        inRange = false;
    }

    void Update()
    {
        updateTextStatus();
        updateBuyTimer();
    }

    void updateBuyTimer()
    {
        if (buyTimer > 0)
        {
            buyTimer -= Time.deltaTime;
        }
        else
        {
            buyTimer = 0;
        }
    }

    void updateTextStatus()
    {
        // Decremenet buy timer if there is a wait time
        if (buyTimer > 0)
        {
            buyTimer -= Time.deltaTime;
        } else
        {
            buyTimer = 0;
        }


        // Check if player is within dealers range
        if (inRange)
        {
            PlayerBehavior playerscript = playerReference.GetComponent<PlayerBehavior>();
            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.RightShift)) && buyTimer == 0)
            {
                buyTimer = buyInterval;
                if (item == "handSani" && playerscript.Cash >= cost)
                {
                    playerscript.Cash -= cost;
                    playerscript.handSani++;
                    playerscript.hasBoughtHandSani = true;
                }
                else if (item == "planeTicket" && playerscript.Cash >= cost)
                {
                    playerscript.Cash -= cost;

                    playerscript.hasPlaneTicket = true;
                }
            }

        } 
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" && item == "planeTicket")
        {

            PlayerBehavior playerscript = playerReference.GetComponent<PlayerBehavior>();
            if(playerscript.currentObjective == 14)
            {
                TurnOnMessage();
                inRange = true;
            }

        }
        else if (col.gameObject.tag == "Player")
        {
            TurnOnMessage();
            inRange = true;
        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {
            inRange = false;
            TurnOffMessage();
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
