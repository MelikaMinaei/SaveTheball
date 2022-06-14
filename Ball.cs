using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float randomFactor = 1f;
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    Vector2 paddleToBallVec;
    bool hasStarted = false;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    Level level;

    void Awake()
    {
        CountBalls();
        paddleToBallVec = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void CountBalls()
    {
        level = FindObjectOfType<Level>();
        level.CountBalls();
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    void Update()
    {
        if(! hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVec;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = 
            new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }   
    }
}
