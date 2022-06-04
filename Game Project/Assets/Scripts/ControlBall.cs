using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{
    public Transform controlSpot;
    public LayerMask controlMask;
    public Vector3 Direction { get; set; }

    private GameObject ballHolding;
    public GameButton gameButton1;
    public GameButton gameButton2;

    public float power = 40f;
    public float max = 10f;
    void Update()
    {
        if (ballHolding)
        {
            if (gameButton2.click)
            {
                if (ballHolding)
                {
                    ballHolding.transform.position += Direction;
                    ballHolding.transform.parent = null;
                    if (ballHolding.GetComponent<Rigidbody2D>())
                    {
                        ballHolding.GetComponent<Rigidbody2D>().simulated = true;
                    }
                   
                    ballHolding.transform.parent = null;
                    StartCoroutine(shootBall(ballHolding));
                    ballHolding = null;
                }
            }
        }
        else
        {
            if (gameButton1.click)
            {
                Collider2D controlBall = Physics2D.OverlapCircle(transform.position, 0.06f, controlMask);
                if (controlBall)
                {
                    ballHolding = controlBall.gameObject;
                    ballHolding.transform.position = controlSpot.position;
                    ballHolding.transform.parent = transform;
                    if (ballHolding.GetComponent<Rigidbody2D>())
                    {
                        ballHolding.GetComponent<Rigidbody2D>().simulated = false;
                    }

                }
            }
        }
    }
    IEnumerator shootBall(GameObject Ball)
    {
        if (ballHolding) {
            Vector3 startPoint = Ball.transform.position;
            Vector3 endPoint = transform.position;

            Vector3 force = startPoint - endPoint;
            Vector3 clambedForce = Vector3.ClampMagnitude(force, max) * power;

            Ball.GetComponent<Rigidbody2D>().AddForce(clambedForce , ForceMode2D.Impulse);

            yield return null;
        }
            
    }

}
