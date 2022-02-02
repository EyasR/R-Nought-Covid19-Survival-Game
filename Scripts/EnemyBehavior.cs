using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public bool isCoughing = false;
    public bool hasCovid = false;
    public static float covidRatio = 1f;
    public float coughInterval = 0f;
    public float coughLength = .15f;
    public float viralLoad = 0f;
    public GameObject playerReference;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.Find("AnimatedPlayer");

        if (this.tag == "Infected")
        {
            hasCovid = true;
        }

        coughInterval = Random.Range(5f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCovid)
        {
            if (coughInterval > 0)
            {
                coughInterval -= Time.deltaTime;
            }
            else
            {
                if (coughLength > 0)
                {
                    isCoughing = true;
                    coughLength -= Time.deltaTime;
                }
                else
                {
                    isCoughing = false;
                    coughInterval = Random.Range(5f, 8f);
                    coughLength = .15f;
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Infected" && !this.hasCovid && this.tag != "Robber")
        {
            viralLoad += Time.deltaTime * .1f;
            if (viralLoad >= 1f)
            {
                hasCovid = true;
                this.tag = "Infected";
                viralLoad = 1f;
            }
        }

        if (col.gameObject.tag == "Player" && this.isCoughing && this.hasCovid)
        {
            

            Debug.Log("Player has been coughed on");
            PlayerBehavior playerScript = playerReference.GetComponent<PlayerBehavior>();
            if (playerScript.hasFaceMask)
            {
                playerScript.viralLoad += Random.Range(.002f, .004f);
            }
            else
            {
                playerScript.viralLoad += Random.Range(.005f, .008f);
            }
            
        }
    }
}
