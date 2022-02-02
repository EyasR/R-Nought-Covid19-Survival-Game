using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectedManager : MonoBehaviour
{
    public int totalInfected;
    public int totalPopulation;
    private GameObject[] infectedPopulation;
    private GameObject[] uninfectedPopulation;
    public GameObject playerReference;
    private int objective = 0;
    public string[] objectiveDisplays;

    public Text infectedDisplay;
    

    void Start()
    {
        objective = 0;
        playerReference= GameObject.Find("AnimatedPlayer");
        infectedDisplay = GetComponent<Text>();
        infectedPopulation = GameObject.FindGameObjectsWithTag("Infected");
        totalInfected = infectedPopulation.Length;

        uninfectedPopulation = GameObject.FindGameObjectsWithTag("NPC");
        totalPopulation = uninfectedPopulation.Length + infectedPopulation.Length;
        //infectedDisplay.text = "Infected: " + totalInfected + "\nPopulation: " + totalPopulation;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBehavior playerScript = playerReference.GetComponent<PlayerBehavior>();
        infectedPopulation = GameObject.FindGameObjectsWithTag("Infected");
        totalInfected = infectedPopulation.Length;
        objective = playerScript.currentObjective;

        infectedDisplay.text = "Objective: " + objectiveDisplays[objective] + "\n\nInfected: " + totalInfected + "\nPopulation: " + totalPopulation;
    }


}