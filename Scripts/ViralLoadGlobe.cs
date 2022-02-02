using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViralLoadGlobe : MonoBehaviour
{

    /*
     * Class derived from many tutorials online.
     */

    public PlayerBehavior PlayerBehaviorReference;
    Image ViralGlobe;

    // Start is called before the first frame update
    void Start() {
        //makes sure the timer bar is made.
        ViralGlobe = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        //handles the fill on the timer bar.
       ViralGlobe.fillAmount = PlayerBehaviorReference.viralLoad / 1f;
    }
}
