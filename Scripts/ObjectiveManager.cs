using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    private int currentObjective;
    public GameObject playerReference;
    Text objectiveText;
    public string[] displayList;

    void Start()
    {
        objectiveText.GetComponent<Text>();

        currentObjective = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        objectiveText.text = "Objective: " + currentObjective;
    }
}
