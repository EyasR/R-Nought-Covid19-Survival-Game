using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    private Vector3 newDirection = new Vector3(0f, 1f, 0f);

    public float waitInterval = 0f;
    public float moveInterval = 0f;
    public float enemySpeed = 10f / 8f;
    private int direction;
    private bool recentlyCollided = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        updateMotion();
    }

    void updateMotion()
    {
        // If done waiting, move
        if (waitInterval <= 0)
        {
            // If moving, update position
            if (moveInterval > 0)
            {
                animator.SetBool("isMoving", true);
                transform.position += newDirection * Time.deltaTime * enemySpeed;
                moveInterval -= Time.deltaTime;
            }
            // Done moving, get new direction
            else
            {
                // If recently collided, reverse direction
                if (recentlyCollided)
                {
                    direction = getReverseDirection(direction);
                    recentlyCollided = false;
                } else
                {
                    direction = Random.Range(1, 4);
                }

                // Move Up
                if (direction == 1)
                {
                    newDirection = new Vector3(0f, 1f);
                    animator.SetInteger("Direction", 1);
                }

                // Move Down
                else if (direction == 2)
                {
                    newDirection = new Vector3(0f, -1f);
                    animator.SetInteger("Direction", 2);
                }

                // Move Left
                else if (direction == 3)
                {
                    newDirection = new Vector3(-1f, 0f);
                    animator.SetInteger("Direction", 3);
                }

                // Move Right
                else if (direction == 4)
                {
                    newDirection = new Vector3(1f, 0f);
                    animator.SetInteger("Direction", 4);
                }

                //newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                waitInterval = Random.Range(.25f, 1.5f);
                moveInterval = Random.Range(1f, 3f);
            }


        }
        // Waiting until time is up, then get new direction
        else
        {
            animator.SetBool("isMoving", false);
            waitInterval -= Time.deltaTime;
        }


    }

    // If colliding with anything, wait 1-2 seconds, then go in the opposite direction
    void OnCollisionEnter2D(Collision2D collision)
    {
        recentlyCollided = true;

        // Reset move interval to get an opposite direction
        moveInterval = 0;
    }

    int getReverseDirection(int direction)
    {
        if (direction == 1)
        {
            return 2;
        } 
        else if (direction == 2)
        {
            return 1;
        } 
        else if (direction == 3)
        {
            return 4;
        } else
        {
            return 3;
        }
    }
}
