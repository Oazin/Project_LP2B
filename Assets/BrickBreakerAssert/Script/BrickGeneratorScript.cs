using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickGeneratorScript : MonoBehaviour
{
    [SerializeField]
    protected GameObject prefab_brick;
    protected GameObject[] bricks_list;
    protected int numberOfBricks;

    [SerializeField]
    protected BallScript ref_ballScript;


    protected const float HEIGHT = 0.92f;
    protected const float WIDTH = 1.76f; 

    // Start is called before the first frame update
    void Start()
    {
        InitializeLevels();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfBricks == 0) 
        {
            ref_ballScript.ResetBall();
            InitializeLevels();
        }
    }

    // InitializeLevels is call at the start or the end of the game to generate a level randomly
    protected void InitializeLevels()
    {
       float posX = -8f;
        float posY = 2.5f;
        for (int j=0; j<5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                float createBrick = Random.Range(0, 10);
                if (createBrick >= 3)
                {
                    GameObject newBrick1 = Instantiate(prefab_brick);
                    newBrick1.transform.position = new Vector3(posX/2, posY/2, 0);
                    numberOfBricks++;
                    GameObject newBrick2 = Instantiate(prefab_brick);
                    newBrick2.transform.position = new Vector3(-posX / 2, posY / 2, 0);
                    numberOfBricks++;
                }
                
                posX += WIDTH;  
            }
            posX = -8f;
            posY += HEIGHT;
        }

    }

    // ReduceNumberOfBricks reduce the number of the brick in the game
    public void ReduceNumberOfBricks()
    {
        numberOfBricks--;
    }

    // ResetTheLevel rest all the level. First, it destroy all the bricks. Secondly, it initialize a new level
    public void ResetTheLevel()
    {
        bricks_list = GameObject.FindGameObjectsWithTag("Bricks");

        foreach (GameObject brick in bricks_list) {
            Destroy(brick);
            ReduceNumberOfBricks();
        }
        InitializeLevels();

    }

}
