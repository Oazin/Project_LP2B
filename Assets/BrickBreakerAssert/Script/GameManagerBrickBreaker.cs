using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBrickBreaker : MonoBehaviour
{
    // References of the canvas usefull
    [SerializeField]
    protected GameObject gameOverCanvas;
    [SerializeField] 
    protected GameObject StartCanvas;
    [SerializeField]
    protected GameObject PauseCanvas;

    protected bool InPlay = false;

    [SerializeField]
    protected WhiteFader fader;

    // References of the different scripts usefull for restart the game
    [SerializeField]
    protected BallScript ref_ballScript;
    [SerializeField]
    protected BrickGeneratorScript ref_BrickGeneratorScript;
    [SerializeField]
    protected PaddleScript ref_paddleScript;



    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false); // Hide the game over canvas
        StartCanvas.SetActive(true); // Show the start canvas
        PauseCanvas.SetActive(false); // hide the pause canvas
    }

    // Update is called once per frame
    void Update()
    {
        if (InPlay)
        {
            Time.timeScale = 1f; // Put the time on. So, it is possible to play
        } else
        {
            Time.timeScale = 0f; // put the time off like the game is in paused
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    // Play is called when the player click on the button "play" to play at the game
    public void Play()
    {
        StartCanvas.SetActive(false); // Hide the start canvas
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
        ref_ballScript.ResetBall();
        ref_ballScript.ResetLifes();
        ref_BrickGeneratorScript.ResetTheLevel();
        ref_paddleScript.ResetThePaddle();
        ref_paddleScript.ResetTheScore();
        gameOverCanvas.SetActive(false);
        InPlay = true;
    }

    protected IEnumerator LoadMenuPage()
    {
        yield return new WaitForSecondsRealtime(fader.LoadFadeOut());
        
        AsyncOperation loader = SceneManager.LoadSceneAsync("MainMenu");
        while (!loader.isDone)
        {
            yield return null;
        }
    }

    // Menu is called when the player click on button "Menu". That load the scene of the main menu 
    public void Menu()
    {
        StartCoroutine(LoadMenuPage());

    }

    // Pause is called when the user press the key "Escape". That show the pause canvas and put the time off 
    public void Pause()
    {
        PauseCanvas.SetActive(true); // Show the pause canvas
        InPlay = false;
    }

    // Continue is called when the player click on button "Continue".
    public void Continue()
    {
        PauseCanvas.SetActive(false); // hide the pause canvas
        InPlay = true; 
    }
}
