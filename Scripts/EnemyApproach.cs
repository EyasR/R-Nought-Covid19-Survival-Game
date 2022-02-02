using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyApproach : MonoBehaviour
{
    private Vector3 newDirection = new Vector3(0f, 1f, 0f);

    public float waitInterval = 0f;
    public float moveInterval = 0f;
    private float enemySpeed = 10f / 6f;
    private float runSpeed = (10f /3f);
    private int randomNum;
    public int direction = 0;
    public bool isFollowing = false;
    public bool isRobber = true;
    public bool hasStolenMoney = false;

    public Animator animator;
    public Transform playerReference;

    void Start()
    {
        if(this.tag == "Robber")
        {
            isRobber = true;
        }
        randomNum = Random.Range(1, 4);
        playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing && !hasStolenMoney)
        {
            approachPlayer();

        }
        else
        {
            wander();
        }
    }


    void approachPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, playerReference.position, runSpeed * Time.deltaTime);
        direction = getDirection();
        animator.SetBool("isMoving", true);
        animator.SetInteger("Direction", direction);
    }

    int getDirection()
    {
        int temp;

        // First Quadrant
        if (playerReference.transform.position.x > this.transform.position.x && playerReference.transform.position.y > this.transform.position.y)
        {
            // If change in y >= change in x, animate up
            if ((playerReference.transform.position.y - this.transform.position.y) >= (playerReference.transform.position.x - this.transform.position.x))
            {
                temp = 1;
            }
            // otherwise, animate right
            else
            {
                temp = 4;
            }
        }


        // Second Quadrant
        else if (playerReference.transform.position.x < this.transform.position.x && playerReference.transform.position.y > this.transform.position.y)
        {
            // If change in y >= change in x, animate up
            if ((playerReference.transform.position.y - this.transform.position.y) >= (this.transform.position.x - playerReference.transform.position.x))
            {
                temp = 1;
            }
            // otherwise, animate left
            else
            {
                temp = 3;
            }
        }

        // Third Quadrant
        else if (playerReference.transform.position.x < this.transform.position.x && playerReference.transform.position.y < this.transform.position.y)
        {
            // If change in y >= change in x, animate up
            if ((this.transform.position.y - playerReference.transform.position.y) >= (this.transform.position.x - playerReference.transform.position.x))
            {
                temp = 2;
            }
            // otherwise, animate right
            else
            {
                temp = 3;
            }
        }

        // Fourth Quadrant
        else if (playerReference.transform.position.x > this.transform.position.x && playerReference.transform.position.y < this.transform.position.y)
        {
            // If change in y >= change in x, animate up
            if ((this.transform.position.y - playerReference.transform.position.y) >= (playerReference.transform.position.x - this.transform.position.x))
            {
                temp = 2;
            }
            // otherwise, animate right
            else
            {
                temp = 4;
            }
        }

        // Directly Up
        else if (playerReference.transform.position.x == this.transform.position.x && playerReference.transform.position.y > this.transform.position.y)
        {
            // Animate Up
            temp = 1;
        }

        // Directly Down
        else if (playerReference.transform.position.x == this.transform.position.x && playerReference.transform.position.y < this.transform.position.y)
        {
            // Animate Down
            temp = 2;
        }

        // Directly Left
        else if (playerReference.transform.position.x < this.transform.position.x && playerReference.transform.position.y == this.transform.position.y)
        {
            // Animate Left
            temp = 3;
        }

        // Directly Right
        else
        {
            // Animate Right
            temp = 4;
        }

        return temp;
    }

    void wander()
    {
        if (waitInterval <= 0)
        {
            if (moveInterval > 0)
            {
                animator.SetBool("isMoving", true);
                transform.position += newDirection * Time.deltaTime * enemySpeed;
                moveInterval -= Time.deltaTime;
            }
            else
            {
                randomNum = Random.Range(1, 4);


                // Move Up
                if (randomNum == 1)
                {
                    newDirection = new Vector3(0f, 1f);
                    animator.SetInteger("Direction", 1);
                }

                // Move Down
                else if (randomNum == 2)
                {
                    newDirection = new Vector3(0f, -1f);
                    animator.SetInteger("Direction", 2);
                }

                // Move Left
                else if (randomNum == 3)
                {
                    newDirection = new Vector3(-1f, 0f);
                    animator.SetInteger("Direction", 3);
                }

                // Move Right
                else if (randomNum == 4)
                {
                    newDirection = new Vector3(1f, 0f);
                    animator.SetInteger("Direction", 4);
                }

                //newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                waitInterval = Random.Range(.25f, 1.5f);
                moveInterval = Random.Range(1f, 3f);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
            waitInterval -= Time.deltaTime;
        }
    }

    // Approach player if they are within radius
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFollowing = true;
        }
    }

    // Stop approaching Player if they are within radius
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFollowing = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRobber && collision.gameObject.tag == "Player"  && !hasStolenMoney)
        {
            PlayerBehavior playerScript = playerReference.GetComponent<PlayerBehavior>();
            if (playerScript.Cash > 0)
            {
                Debug.Log("you have: " + playerScript.Cash);
                if (playerScript.Cash >= 150 && !hasStolenMoney)
                {
                    playerScript.Cash -= 150;
                }
                else
                {
                    playerScript.Cash = 0;
                 
                }
                
                Debug.Log("stole your money boii: " + playerScript.Cash);
                
            }
            hasStolenMoney = true;
        }
    }
}
