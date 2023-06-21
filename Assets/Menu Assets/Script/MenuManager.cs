using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    protected AudioClip ref_SelectSound;
    protected AudioSource sfx_SelectSound;

    [SerializeField]
    protected WhiteFader fader;

    [SerializeField]
    protected GameObject trollCanvas;
    [SerializeField]
    protected GameObject MenuCanvas;
    [SerializeField]
    protected Button buttonYes;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        sfx_SelectSound = gameObject.AddComponent<AudioSource>();
        sfx_SelectSound.clip = ref_SelectSound;
        trollCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    // Coroutine to load game's page in async
    protected IEnumerator LoadAppleCatcherPage()
    {
        yield return new WaitForSecondsRealtime(fader.LoadFadeOut());

        AsyncOperation loader = SceneManager.LoadSceneAsync("AppleCatcherTitle");
        while (!loader.isDone)
        {
            yield return null;
        }
    }

    // Method to load the scene of Apple Catcher game
    public void AppleCatcher()
    {

        sfx_SelectSound.Play();
        StartCoroutine(LoadAppleCatcherPage());
    }

    // Coroutine to load game's page in async
    protected IEnumerator LoadBrickBreakerPage()
    {
        yield return new WaitForSecondsRealtime(fader.LoadFadeOut());

        AsyncOperation loader = SceneManager.LoadSceneAsync("BrickBreaker");
        while (!loader.isDone)
        {
            yield return null;
        }
    }

    // Method to load the scene of Brick Breaker game
    public void BrickBreaker()
    {
        sfx_SelectSound.Play();
        StartCoroutine(LoadBrickBreakerPage());
    }

    // Coroutine to load game's page in async
    protected IEnumerator LoadFurapiBirdPage()
    {
        yield return new WaitForSecondsRealtime(fader.LoadFadeOut());

        AsyncOperation loader = SceneManager.LoadSceneAsync("FurapiBird");
        while (!loader.isDone)
        {
            yield return null;
        }
    }

    // Method to load the scene of Furapi Bird game
    public void FurapiBird()
    {
        sfx_SelectSound.Play();
        StartCoroutine (LoadFurapiBirdPage());
    }

    // Method to quit the application
    public void Quit()
    {
        Application.Quit();
    }

    //------------------------------------------------------------
    // ------------- The Easter Eat in the main menu -------------
    //------------------------------------------------------------

    // When you press the but yes it place change like you can't leave the game but in fact the button quit on the left-bottom corner you can quit. 
    // Method the show he troll canvas
    public void TrollQuitButton()
    {
        trollCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }

    // Method to return an the canvas to select the game
    public void No()
    {
        trollCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    // Method which change the place of the yes button in order to the player can't leave the game
    public void Yes()
    {
        buttonYes.transform.position = new Vector3(Random.Range(-8,8), Random.Range(-4, 4), 0f);

    }

}
