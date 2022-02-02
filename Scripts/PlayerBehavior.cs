using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float viralLoad = 0.0f;
    public float walkSpeed = .005f;
    public float moveSpeed;
    private float runSpeed = 1.2f;
    public float stamina = 1f;
    public float exhausted = 1f;
    public int returnId = 0;
    public int Cash = 0;
    public int handSani = 0;
    private float handSaniCooldown = 5f;
    public float handSaniTimer;
    public float viralDrainAmount;
    public float viralDrain;
    public int cashPenalty = 500;
    public float damageSoundTimer;
    private const float damageInterval = .25f;

    public Canvas GameOverCanvas;
    public bool GameOver;

    private bool recievedInput;
    public bool isInside;
    public bool hasFaceMask;
    public bool hasGloves;
    private bool devMode = false;
    public bool hasBoughtHandSani;
    public bool hasPlaneTicket;

    public int currentObjective;
    public Animator animator;
    public AudioSource deathEffect;
    public AudioSource damageTaken;
    public AudioSource upgrade;

    void Start()
    {
        damageSoundTimer = damageInterval;
        hasBoughtHandSani = false;
        hasFaceMask = false;
        hasGloves = false;
        isInside = false;
        hasPlaneTicket = false;
        GameOver = false;
        animator.SetBool("isMoving", false);
        animator.SetInteger("Direction", 2);
        currentObjective = 0;
        


        handSaniTimer = handSaniCooldown;
        //deathEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            updateMotion();
        }
        updateViralLoad();
        updateObjective();
        updateDamageSound();
        updateDevMode();
     
    }

    void updateDevMode()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
           
            Cash = 10000;
            handSani = 10;
        }

    }
    void updateMotion()
    {
        // Sprint Behavior
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            moveSpeed = walkSpeed * runSpeed;
            stamina -= Time.deltaTime * .4f;
            if (stamina <= 0)
            {
                stamina = 0;
                exhausted = 1f;
            }
        }
        else if (exhausted <= 0)
        {
            stamina += Time.deltaTime * .3f;
            moveSpeed = walkSpeed;
            if (stamina > 1f)
            {
                stamina = 1f;
            }
        }
        else if (exhausted > 0)
        {
            exhausted -= Time.deltaTime;
            if (exhausted < 0)
            {
                exhausted = 0;
            }
            moveSpeed = walkSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        recievedInput = false;

        // Keyboard Movement WASD

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * moveSpeed;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 1);
            recievedInput = true;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * moveSpeed;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 2);
            recievedInput = true;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 3);
            recievedInput = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 4);
            recievedInput = true;
        }
        if (!recievedInput)
        {
            animator.SetBool("isMoving", false);
        }
    }

    void updateViralLoad()
    {
        if (handSaniTimer > 0)
        {
            handSaniTimer -= Time.deltaTime;
            if (viralDrain < viralDrainAmount)
            {
                float temp = Time.deltaTime * .06f;
                if (viralDrain + temp > viralDrainAmount)
                {
                    viralLoad -= (viralDrainAmount - viralDrain);
                    viralDrain = viralDrainAmount;
                } else if (viralLoad - temp < 0) {
                    viralDrain = viralDrainAmount;
                    viralLoad = 0;
                }
                else
                {
                    viralDrain += temp;
                    viralLoad -= temp;
                }
            }
        } else
        {
            handSaniTimer = 0;
        }

        viralLoad -= Time.deltaTime * 0.002f;
        if (viralLoad < 0f)
        {
            viralLoad = 0f;
        }


        if (Input.GetKeyDown(KeyCode.R) && handSaniTimer == 0 && handSani > 0)
        {
            handSaniTimer = handSaniCooldown;
            if (viralLoad >= .3f)
            {
                viralDrain = 0f;
                viralDrainAmount = .3f;
            } else if (viralLoad > 0)
            {
                viralDrain = 0f;
                viralDrainAmount = viralLoad;
            }
            handSani--;
        }
    }

    void updateObjective()
    {
        if ((currentObjective == 4 || currentObjective == 5) && Cash < 150 && hasFaceMask == false)
        {
            currentObjective = 2;
        } else if (currentObjective == 2 && Cash >= 150)
        {
            currentObjective = 4;
        } 

        if (currentObjective == 5 && hasFaceMask == true)
        {
            currentObjective++;
        }


        if (currentObjective == 7 && hasGloves)
        {
            currentObjective = 9;
        }
        if (currentObjective == 11 && hasBoughtHandSani)
        {
            upgrade.Play();
            currentObjective = 13;
        }
        if (currentObjective == 14 && hasPlaneTicket)
        {
            upgrade.Play();
            currentObjective = 16;
        }
        if (currentObjective == 17)
        {
            GameOverCanvas.enabled = true;
            GameOver = true;
        }


    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Infected")
        {
            if (viralLoad < 1f && hasGloves)
            {
                if(damageSoundTimer == 0)
                {
                    damageSoundTimer = damageInterval;
                    damageTaken.Play();
                }
                
                viralLoad += 0.03f * Time.deltaTime;
            }
            else if (viralLoad < 1f && !hasGloves)
            {
                if (damageSoundTimer == 0)
                {
                    damageSoundTimer = damageInterval;
                    damageTaken.Play();
                }
                viralLoad += 0.05f * Time.deltaTime;
            }
            else
            {
                // Go to the hospital
                deathEffect.Play();
                transform.position = new Vector3(197.5612f, 200.8905f, 0f);
                viralLoad = 0f;
                if (Cash >= cashPenalty)
                {
                    Cash -= cashPenalty;
                } else
                {
                    Cash = 0;
                }
            }
        }
    }

    void updateDamageSound()
    {
        if (damageSoundTimer > 0)
        {
            damageSoundTimer -= Time.deltaTime;
        }
        else
        {
            damageSoundTimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Picking up Facemask
        if (col.gameObject.name == "FaceMask")
        {
            if (Cash >= 150)
            {
                upgrade.Play();
                hasFaceMask = true;
                Cash -= 150;
                currentObjective = 6;
            }
        }

        // Picking up Gloves
        if (col.gameObject.name == "Gloves")
        {
            upgrade.Play();
            hasGloves = true;
        }

        // Objectives
        if (col.gameObject.tag == "Objective")
        {
            if (col.gameObject.name == "Waypoint " + (currentObjective + 1))
            {
                currentObjective++;
            }
        }
    }
}
