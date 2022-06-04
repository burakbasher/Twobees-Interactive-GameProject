using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public Joystick movementJoystick;
    public float playerSpeed = 0.2f;
    private float maxSpeed = 0.4f;
    private float minSpeed = 0.25f;
    private Rigidbody2D rb;
    public float accelerationTime = 5f;
    private float time;
    public Animator animator;
    private ControlBall controlBall;
    private Vector3 vector3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpeed = minSpeed;
        time = 0;
        controlBall = gameObject.GetComponent<ControlBall>();
        controlBall.Direction = new Vector2(0.1f, 0); 
    }
    private void Update() 
    {
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        if (vector3.sqrMagnitude > 0.1f)
        {
            controlBall.Direction = vector3.normalized * 0.1f;
        }
    }
    void FixedUpdate()
    {
        
        if (movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
            vector3 = rb.velocity;
            playerSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, 3 * time / accelerationTime);
            time += Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
            playerSpeed = minSpeed;
            time = 0;
        }
       
    }

}