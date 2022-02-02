using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSaniManager : MonoBehaviour
{
    public GameObject playerReference;
    public PlayerBehavior playerScript;
    public Text handSaniDisplay;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        handSaniDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScript = playerReference.GetComponent<PlayerBehavior>();

        handSaniDisplay.text = "" + playerScript.handSani;
    }
}
