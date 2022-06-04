using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRunning : MonoBehaviour
{
    public GameObject Ball;
    public bool moving;
    public Animator animator;

    private void Update()
    {
        if(Ball.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        animator.SetBool("Moving", moving);
    }
}
