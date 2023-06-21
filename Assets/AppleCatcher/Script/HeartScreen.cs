using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartScreen : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] hearts;
    protected int lives = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            //Change the scene and show the score
            StartCoroutine(LoadMainGame());
        }
    }

    public void ReductNumberOfLife()
    {
        Debug.Log(hearts.Length);
        DestroyImmediate(hearts[lives-1]);
        --lives;
    }

    protected IEnumerator LoadMainGame()
    {
        AsyncOperation loader = SceneManager.LoadSceneAsync("AppleCatcherTitle");
        while (!loader.isDone)
        {
            yield return null;
        }
    }
}
