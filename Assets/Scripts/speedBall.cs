using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBall : MonoBehaviour
{
    public float forceAmount;
    private Rigidbody2D rb;
    public float ballSpeed = 400f;
    public bool ballMoving;
    public Transform ballPos;
    public float maxBallSpeed = 1000f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {

        if (ballMoving == false)
        {
            transform.position = ballPos.position;
        }

        if (Input.GetButtonDown("Jump") & ballMoving == false)
        {
            ballMoving = true;
            rb.AddForce(Vector2.up * ballSpeed);
        }
        
        if (ballMoving == true)
        {
            ballSpeed += 20f;
            if (ballSpeed >= maxBallSpeed)
            {
                ballSpeed = maxBallSpeed;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Paddle" && ballMoving == true)
        {
            rb.AddForce(rb.velocity * forceAmount, ForceMode2D.Force);
        }
    }
}
