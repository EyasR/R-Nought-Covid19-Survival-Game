using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    private Vector3 newDirection = new Vector3(0f, 1f, 0f);

    public float waitInterval = 0f;
    public float moveInterval = 0f;
    public float enemySpeed = 10f / 8f;
    private int randomNum;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        updateMotion();
    }

    void updateMotion()
    {
        if (waitInterval <= 0)
        {
            if (moveInterval > 0)
            {
                animator.SetBool("isMoving", true);
                // transform.position += newDirection * Time.deltaTime * enemySpeed;
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
                waitInterval = Random.Range(3f, 6f);
                moveInterval = .01f;
            }


        }
        else
        {
            animator.SetBool("isMoving", false);
            waitInterval -= Time.deltaTime;
        }


    }
}
