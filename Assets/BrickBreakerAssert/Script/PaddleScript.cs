using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    // Score's variables
    [SerializeField]
    protected TextMeshPro ref_score;
    protected int score;

    // Speed of the paddle deplacement 
    protected float SPEED = 6.0f;


    // Update is called once per frame
    void Update()
    {
        if  (Input.GetKey(KeyCode.Q)) 
        {
            if (transform.position.x > -3.51)
            {
                transform.Translate(-SPEED * Time.deltaTime, 0, 0);
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 3.51)
            {
                transform.Translate(SPEED * Time.deltaTime, 0, 0);
            }
                
        }
    }

    // IncreaseScore is called each time of the ball destroy a brick the score iscreases of 100 points
    public void IncreaseScore()
    {
        score += 100;
        ref_score.SetText("Score : " + score);
    }

    // ResetTheScore is called when the player had loose and when to replay. It resets the score at 0
    public void ResetTheScore()
    {
        score = 0;
        ref_score.SetText("Score : " + score);
    }

    // ResetThePaddle is called when the player had loose and when to replay. That resets the position of the paddle
    public void ResetThePaddle()
    {
        score = 0;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    // When the Extra point is trigger by the paddle 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ExtraPoint"))
        {
            score += 500;
            ref_score.SetText("Score : " + score);
            Destroy(collision.gameObject);
        }
    }
}
