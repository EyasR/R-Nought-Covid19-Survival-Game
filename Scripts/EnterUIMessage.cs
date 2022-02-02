using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterUIMessage : MonoBehaviour
{

    public Text message;
    public string output;

    // Start is called before the first frame update
    void Start()
    {
        output = "[PRESS E TO ENTER]";
        
        message = GetComponent<Text>();
        message.text = "";

    }

}
