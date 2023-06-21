using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Bird_Script : MonoBehaviour
{
    // reference to the game manager 
    [SerializeField] protected GameManagerFurapiBird ref_gameManager;

    // reference to the bird animation
    [SerializeField] protected BirdAnimation ref_birdAnimation;

    // Bird flying's variables
    [SerializeField]
    protected Rigidbody2D rb;
    protected const float VELOCTY = 4f;

    // Score's variables
    [SerializeField]
    protected TextMeshPro ref_score;
    protected int score;

    // Sound's variables
    [SerializeField]
    protected AudioClip[] ref_audioClip;
    protected AudioSource sfx_death;
    protected AudioSource sfx_impact;
    protected AudioSource sfx_music;


    // Start is called before the first frame update
    void Start()
    {
        sfx_death = gameObject.AddComponent<AudioSource>();
        sfx_impact = gameObject.AddComponent<AudioSource>();
        sfx_music = gameObject.AddComponent<AudioSource>();
        sfx_death.clip = ref_audioClip[0];
        sfx_impact.clip = ref_audioClip[1];
        sfx_music.clip = ref_audioClip[2];
        sfx_music.Play();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // You have the possiblity to press Space bar
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * VELOCTY;
        }
        
        // Check to be sure if the player does'nt go out the window
        if (transform.position.y > 4.5 || transform.position.y < -4.5)
        {
            BirdDead();
        }
    }   

    // Method in the case of collision with a game object
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // if the game object is the space between the top and the bottom pipe the score increases
        if (collision.gameObject.tag == "Space")
        {
            score++;
            ref_score.SetText("Score : " + score);
        } else // Else the game object is a part of the pipe. So, the game is stoped 
        {
            sfx_impact.Play();
            BirdDead();
        }
        

    }

    // Method which called the GameOver method to stop the game
    protected void BirdDead()
    {
        sfx_music.Stop();
        sfx_death.Play();
        ref_gameManager.GameOver();
        ref_birdAnimation.AnimateDeadBird();
        
    }

    // ResetBird rest the default position and the velocity of the bird
    public void ResetBird()
    {
        transform.position = new Vector3(transform.position.x, 0 , transform.position.z);
        rb.velocity = Vector2.zero;
    }

    // ResetScore rest the score at zero
    public void ResetScore()
    {
        score = 0;
        ref_score.SetText("Score : " + score);
    }
}
