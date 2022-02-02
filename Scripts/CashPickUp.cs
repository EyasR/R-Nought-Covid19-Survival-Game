using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickUp : MonoBehaviour
{
    public int StackSize;
    public int BottomRange;
    public int TopRange;
    public GameObject playerReference;
    public PlayerBehavior playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.Find("AnimatedPlayer");
        playerScript = playerReference.GetComponent<PlayerBehavior>();
        StackSize = Random.Range(BottomRange, TopRange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            
            playerScript.Cash += StackSize;
            Object.Destroy(this.gameObject);
        }
    }
}
