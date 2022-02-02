using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject[] waypoints;
    private int Direction;
    private bool isHorizontal;
    private bool incrementUp;
    private int index;
    private float bounds;
    public float walkSpeed = 10f / 8f;
    int increment = 0;
    public bool isLooping;
    private Vector3 newDirection = new Vector3(0f, 0f, 0f);

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        incrementUp = true;
        increment = 1;
        index = 0;
        bounds = .5f;

        getDirection();
        //this.transform.position = waypoints[index].transform.position + newDirection;
    }

    // Update is called once per frame
    void Update()
    {
        // Standard Movement
        if (isWithinThreshHold())
        {
            getDirection();
            this.transform.position += newDirection * Time.deltaTime * walkSpeed;
        }

        // Get back in bounds
        else
        {
            // Moving Vertically
            if (!isHorizontal)
            {
                // To the left of bounds, so move right
                if (this.transform.position.x < waypoints[index].transform.position.x - bounds)
                {
                    animator.SetInteger("Direction", 4);
                    newDirection = new Vector3(1f, 0f, 0f);
                    this.transform.position += newDirection * Time.deltaTime * walkSpeed;
                }
                // To the right of bounds, so move left
                else if (this.transform.position.x > waypoints[index].transform.position.x + bounds)
                {
                    animator.SetInteger("Direction", 3);
                    newDirection = new Vector3(-1f, 0f, 0f);
                    this.transform.position += newDirection * Time.deltaTime * walkSpeed;
                }
            }

            // Moving Horizontally
            else
            {
                // Above bounds, so move down
                if (this.transform.position.y > waypoints[index].transform.position.y + bounds)
                {
                    animator.SetInteger("Direction", 2);
                    newDirection = new Vector3(0f, -1f, 0f);
                    this.transform.position += newDirection * Time.deltaTime * walkSpeed;
                }
                // Below bounds, so move up
                else if (this.transform.position.y < waypoints[index].transform.position.y - bounds)
                {
                    animator.SetInteger("Direction", 1);
                    newDirection = new Vector3(0f, 1f, 0f);
                    this.transform.position += newDirection * Time.deltaTime * walkSpeed;
                }

            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Waypoint" && collision.gameObject == waypoints[(index + increment) % waypoints.Length])
        {
            
            if (isLooping)
            {
                index = (index + 1)%waypoints.Length;
                return;
            }




            
            if (incrementUp && index < waypoints.Length - 1)
            {
                    
                increment = 1;
                index++;
                if(index == waypoints.Length - 1)
                {
                    increment = -1;
                    incrementUp = false;
                }
            }
            else if (incrementUp && index == waypoints.Length - 1)
            {
                incrementUp = false;
                increment = -1;
                index--;
            }
            else if (!incrementUp && index > 0)
            {
                increment = -1;
                index--;
                if(index == 0)
                {
                    increment = 1;
                    incrementUp = true;
                }
            }
            else
            {
                incrementUp = true;
                increment = 1;
                index++;
            }
        }
        getDirection();
    }



    void getDirection()
    {
        // Moving Vertically
        if (waypoints[index].transform.position.x == waypoints[(index + increment)% waypoints.Length].transform.position.x)
        {
            isHorizontal = false;
            // Moving Up
            if (waypoints[index].transform.position.y < waypoints[(index + increment) % waypoints.Length].transform.position.y)
            {
                Direction = 1;
                animator.SetBool("isMoving", true);
                animator.SetInteger("Direction", Direction);
                newDirection = new Vector3(0f, 1f, 0f);
            }
            // Moving Down
            else
            {
                Direction = 2;
                animator.SetBool("isMoving", true);
                animator.SetInteger("Direction", Direction);
                newDirection = new Vector3(0f, -1f, 0f);
            }
        }
        // Moving Horizontally
        else
        {
            isHorizontal = true;

            // Moving Right
            if (waypoints[index].transform.position.x < waypoints[(index + increment) % waypoints.Length].transform.position.x)
            {
                Direction = 4;
                animator.SetBool("isMoving", true);
                animator.SetInteger("Direction", Direction);
                newDirection = new Vector3(1f, 0f, 0f);
            }
            // Moving Left
            else
            {
                Direction = 3;
                animator.SetBool("isMoving", true);
                animator.SetInteger("Direction", Direction);
                newDirection = new Vector3(-1f, 0f, 0f);
            }
        }

    }

    bool isWithinThreshHold()
    {
        // Check Vertical
        if (!isHorizontal)
        {
            // Check if to the left of threshold
            if (this.transform.position.x < waypoints[index].transform.position.x - bounds)
            {
                return false;
            }
            // Check if to the right of threshold
            else if (this.transform.position.x > waypoints[index].transform.position.x + bounds)
            {
                return false;
            }
            // Within bounds
            else
            {
                return true;
            }
        }

        // Check Horizontal
        else
        {
            // Check if above the threshold
            if (this.transform.position.y > waypoints[index].transform.position.y + bounds)
            {
                return false;
            }
            // Check if below the threshold
            else if (this.transform.position.y < waypoints[index].transform.position.y - bounds)
            {
                return false;
            }
            // Within bounds
            else
            {
                return true;
            }
        }
    }
}

