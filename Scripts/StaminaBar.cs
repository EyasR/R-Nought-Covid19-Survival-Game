using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerBehavior PlayerBehaviorReference;
    Image staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        //makes sure the timer bar is made.
        staminaBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //handles the fill on the timer bar.
        staminaBar.fillAmount = PlayerBehaviorReference.stamina/ 1f;
    }
}
