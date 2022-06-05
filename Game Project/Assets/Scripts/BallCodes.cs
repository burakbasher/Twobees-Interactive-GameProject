using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BallCodes : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 Velocity;

    [HideInInspector]
    public int Score = 0;
    public GameObject Player;
    private Animator anim;
    private Vector3 respawnPointBall;
    private Vector3 respawnPointPlayer;
    private Vector3 randomPosition;

    private float yAxis;
    private float xAxis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        respawnPointBall = transform.position;
        respawnPointPlayer = Player.transform.position;
    }

    void Update()
    {
        Velocity = rb.velocity;
        if(transform.position == randomPosition)
        {
            Player.GetComponent<Animator>().SetBool("NewGoal", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Post")
        {
            var speed = Velocity.magnitude;
            var direction = Vector3.Reflect(Velocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Player.GetComponent<Animator>().SetBool("NewGoal", true);
            Score += 1;
            yAxis = RandomFloatGenerate(0, 1);
            xAxis = RandomFloatGenerate(-1, 1);
            randomPosition = new Vector3(xAxis, yAxis, 0);
            transform.position = randomPosition;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Debug.Log(Score + " Goal! Nice Shot!");
            Player.GetComponent<Animator>().Play("Player_goal_celebration");
            
            Player.transform.position = respawnPointPlayer;
            Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            

        }
        else if(collision.tag == "Out")
        {
            Debug.Log("The ball has gone out!");
            yAxis = RandomFloatGenerate(0f, 0.6f);
            xAxis = RandomFloatGenerate(-0.6f, 0.6f);
            randomPosition = new Vector3(xAxis, yAxis, 0);
            transform.position = randomPosition;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    private float RandomFloatGenerate(float min, float max)
    {
        float range = max - min;
        System.Random random = new System.Random();
        float val = (float)random.NextDouble();
        float offset = (val * range) + min;
        return val;
    }

}
