using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationary : MonoBehaviour
{
    public int direction;
    public Animator animator;

    // Update is called once per frame
    void Start()
    {
        animator.SetBool("isMoving", true);
        animator.SetInteger("Direction", direction);
        animator.SetBool("isMoving", false);
    }
}
