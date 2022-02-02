using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour
{
    public GameObject playerReference;
    public PlayerBehavior playerScript;
    public Text cashDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        cashDisplay = GetComponent<Text>();

        
    }

    // Update is called once per frame
    void Update()
    {
        playerScript = playerReference.GetComponent<PlayerBehavior>();
        
        cashDisplay.text = "$" + playerScript.Cash;
    }


}
