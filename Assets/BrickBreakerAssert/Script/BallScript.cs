using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    protected AudioClip[] ref_audioClips;

    protected AudioSource paddleContact;
    protected AudioSource wallContact;
    protected AudioSource winPoint;
    protected AudioSource loselife;

    [SerializeField]
    protected Rigidbody2D rb;
    protected const float SPEED = 300f;
    protected bool InPlay = false;
    protected const float SCREENBOTTOM= -4.6f;

    [SerializeField]
    protected Transform paddle;
    [SerializeField]
    protected PaddleScript ref_Score;
    
    [SerializeField]
    protected TextMeshPro ref_lifes;
    protected int lifes = 3;

    [SerializeField]
    protected BrickGeneratorScript ref_numberOfBrick;

    [SerializeField]
    protected GameManagerBrickBreaker ref_GM;

  


    // Start is called before the first frame update
    void Start()
    {
        paddleContact = gameObject.AddComponent<AudioSource>();
        paddleContact.clip = ref_audioClips[0];
        wallContact = gameObject.AddComponent<AudioSource>();
        wallContact.clip = ref_audioClips[1];
        winPoint = gameObject.AddComponent<AudioSource>();
        winPoint.clip = ref_audioClips[2];
        loselife = gameObject.AddComponent<AudioSource>();
        loselife.clip = ref_audioClips[3];
    }

    // Update is called once per frame
    void Update()
    {
        // The aim is to allow of the player to chose where he wants to free the ball because it follow the movement of the paddle
       if (!InPlay)
        {
            ResetBall();
        }
       // When the player press the key 'Space' the ball is free 
       if (Input.GetKey(KeyCode.Space) && !InPlay) 
        { 
            InPlay = true;
            rb.AddForce(Vector2.up * SPEED);
        }
       // If the ball go out of the screen by the bottom, the ball go back to it initilize possition and the player lose a life
       if (transform.position.y < SCREENBOTTOM)
        {
            InPlay = false;
            rb.velocity = new Vector2(0, 0);
            ReduceNumberOfLife();
        }
       // If the player hasn't life the game is stoped and show the game over window
        if (lifes <= 0)
        {
            InPlay = false;
            ref_GM.GameOver();
        }

    }

    // Override the default method OnCollisionEnter2D in order to affect what to do when you have a collision with game objects 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with the wall : play song of the hit
        if (collision.gameObject.tag == "Wall")
        {
            wallContact.Play();
        }
        // Collision with the paddle : play song of the hit and change it direction 
        if (collision.gameObject.name == "Paddle")
        {
            paddleContact.Play();
            ChangeDirection();
        }
        // Collision with the bircks : Increase the score 
        if (collision.gameObject.CompareTag("Bricks"))
        {
            ref_Score.IncreaseScore();
            ref_numberOfBrick.ReduceNumberOfBricks();
            winPoint.Play();
        }
        
    }

    // Method to change the direction of the ball during collision with the pabble
    // The aim is that the player can "control" the direction of the ball
    protected void ChangeDirection()
    {
        // More the ball hit the paddle on the extrimities of it, more the ball will have angle
        float diffx = transform.position.x - paddle.position.x;
        rb.velocity += new Vector2(diffx *2, 0);
    }

    // Method to reduce the number of lifes of the player and set the TMP on the screen
    protected void ReduceNumberOfLife()
    {
        lifes--;
        ref_lifes.SetText("Lifes :" + lifes);
        loselife.Play();
    }

    // Method to rest the position of the ball
    public void ResetBall()
    {
        transform.position = new Vector3(paddle.position.x, paddle.position.y + 0.7f, 0);
    }

    // Method to rest the number of lifes
    public void ResetLifes()
    {
        lifes = 3;
        ref_lifes.SetText("Lifes :" + lifes);
    }

}
