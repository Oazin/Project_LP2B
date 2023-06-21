using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerFurapiBird : MonoBehaviour
{

    [SerializeField]
    protected GameObject gameOverCanvas;
    [SerializeField]
    protected GameObject startCanvas;
    [SerializeField]
    protected GameObject pauseCanvas;

    protected bool InPlay = false;

    [SerializeField]
    protected WhiteFader fader;


    [SerializeField]
    protected Bird_Script ref_bird_script;
    [SerializeField]
    protected Pipe_Spawner ref_pipe_Spawner;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        startCanvas.SetActive(true); 
        pauseCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (InPlay)
        {
            Time.timeScale = 1f;
        } else
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    // Play is called when the player click on the button "play" to play at the game
    public void Play()
    {
        startCanvas.SetActive(false); // Hide the start canvas
        InPlay = true;
    }

    // GameOver is called when the player has 0 life the game stoped and the player can choose between replay and leave the game to the menu
    public void GameOver()
    {
        gameOverCanvas.SetActive(true); // Show the game over canvas
        InPlay = false;
    }

    // Replay is called when the player click on button "Replay". That reload the scene of the game 
    public void Replay()
    {
        ref_bird_script.ResetBird();
        ref_bird_script.ResetScore();
        ref_pipe_Spawner.RestLevel();
        gameOverCanvas.SetActive(false);
        InPlay = true;
    }

    // Menu is called when the player click on button "Menu". That load the scene of the main menu 
    public void Menu()
    {
        StartCoroutine(LoadMainMenuPage());
    }

    // Coroutine to load menu's page in async
    protected IEnumerator LoadMainMenuPage()
    {
        yield return new WaitForSecondsRealtime(fader.LoadFadeOut());

        AsyncOperation loader = SceneManager.LoadSceneAsync("MainMenu");
        while (!loader.isDone)
        {
            yield return null;
        }
    }

    // Pause is called when the user press the key "Escape". That show the pause canvas and put the time off 
    public void Pause()
    {
        pauseCanvas.SetActive(true); // Show the pause canvas
        InPlay = false;
    }

    // Continue is called when the player click on button "Continue".
    public void Continue()
    {
        pauseCanvas.SetActive(false); // hide the pause canvas
        InPlay = true;
    }

}
