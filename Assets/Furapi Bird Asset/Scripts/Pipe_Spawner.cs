using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Spawner : MonoBehaviour
{

    [SerializeField]
    protected GameObject ref_pipe;
    [SerializeField]
    protected GameObject ref_space;
    protected const float SPAWNTIME = 3f;
    protected float timer;
    protected float height = 3f;
    protected GameObject[] pipe_list;
    protected GameObject[] space_list;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= SPAWNTIME)
        {
            SpawnPipe();
        }

        timer += Time.deltaTime;
    }
    
    protected void SpawnPipe()
    {
        GameObject newpipe = Instantiate(ref_pipe);
        GameObject newspace = Instantiate(ref_space);
        float randomHeight = Random.Range(-height, height);
        newpipe.transform.position = transform.position + new Vector3(10, randomHeight, 0);
        newspace.transform.position = transform.position + new Vector3(10, randomHeight, 0);
        timer = 0;
    }

    protected void DestroyPipeInGame()
    {
        pipe_list = GameObject.FindGameObjectsWithTag("Pipe");
        space_list = GameObject.FindGameObjectsWithTag("Space");

        foreach (GameObject pipe in pipe_list)
        {
            Destroy(pipe);
        }

        foreach (GameObject space in space_list)
        {
            Destroy(space);
        }
    }

    public void RestLevel()
    {
        timer = 0;
        DestroyPipeInGame();
    }

}

