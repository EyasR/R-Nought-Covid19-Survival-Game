using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject playerReference;
    public GameObject doorReference;
    public GameObject totalInfectedRefrence;
    public PlayerBehavior playerScript;

    public AudioSource doorSound;
    

    public int doorId;

    void Start()
    {
        totalInfectedRefrence = GameObject.FindGameObjectWithTag("totalInfected");
        //doorSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {       
         if (col.gameObject.name == "AnimatedPlayer" && (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.RightShift)))
         {
            //doorSound.Play(); 
            playerReference = GameObject.FindGameObjectWithTag("Player");
            playerScript = playerReference.GetComponent<PlayerBehavior>();
            InfectedManager UIScript = totalInfectedRefrence.GetComponent<InfectedManager>();
                
            
            if (this.doorId % 2 == 0)
            {
                playerScript.isInside = true;
                Vector3 Offset = new Vector3(0f,1f,0f);
                playerReference.transform.position = doorReference.transform.position + Offset;
                GameObject.Find("Main Camera").transform.position = playerReference.transform.position;
                UIScript.infectedDisplay.text = "";
    
            }
            else
            {
                playerScript.isInside = false;
                Vector3 Offset = new Vector3(0f, -1f, 0f);
                playerReference.transform.position = doorReference.transform.position + Offset;
                GameObject.Find("Main Camera").transform.position = playerReference.transform.position;
           
                UIScript.infectedDisplay.text = "Infected: " + UIScript.totalInfected + "\nPopulation: " + UIScript.totalPopulation; ;
            }
         }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "AnimatedPlayer" && (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.RightShift)))
        {
            //doorSound.Play(); 
            playerReference = GameObject.FindGameObjectWithTag("Player");
            playerScript = playerReference.GetComponent<PlayerBehavior>();
            InfectedManager UIScript = totalInfectedRefrence.GetComponent<InfectedManager>();


            if (this.doorId % 2 == 0)
            {
                playerScript.isInside = true;
                Vector3 Offset = new Vector3(0f, 1f, 0f);
                playerReference.transform.position = doorReference.transform.position + Offset;
                GameObject.Find("Main Camera").transform.position = playerReference.transform.position;
                UIScript.infectedDisplay.text = "";

            }
            else
            {
                playerScript.isInside = false;
                Vector3 Offset = new Vector3(0f, -1f, 0f);
                playerReference.transform.position = doorReference.transform.position + Offset;
                GameObject.Find("Main Camera").transform.position = playerReference.transform.position;

                UIScript.infectedDisplay.text = "Infected: " + UIScript.totalInfected + "\nPopulation: " + UIScript.totalPopulation; ;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "AnimatedPlayer" && (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.RightShift)))
        {
            //doorSound.Play(); 
            playerReference = GameObject.FindGameObjectWithTag("Player");
            playerScript = playerReference.GetComponent<PlayerBehavior>();
            InfectedManager UIScript = totalInfectedRefrence.GetComponent<InfectedManager>();


            if (this.doorId % 2 == 0)
            {
                playerScript.isInside = true;
                Vector3 Offset = new Vector3(0f, 1f, 0f);
                playerReference.transform.position = doorReference.transform.position + Offset;
                GameObject.Find("Main Camera").transform.position = playerReference.transform.position;
                UIScript.infectedDisplay.text = "";

            }
            else
            {
                playerScript.isInside = false;
                Vector3 Offset = new Vector3(0f, -1f, 0f);
                playerReference.transform.position = doorReference.transform.position + Offset;
                GameObject.Find("Main Camera").transform.position = playerReference.transform.position;

                UIScript.infectedDisplay.text = "Infected: " + UIScript.totalInfected + "\nPopulation: " + UIScript.totalPopulation; ;
            }
        }
    }
}
