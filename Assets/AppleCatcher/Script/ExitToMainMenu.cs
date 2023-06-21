using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{
    [SerializeField]
    protected WhiteFader fader;


    protected IEnumerator LoadMainMenu() {

        yield return new WaitForSecondsRealtime(fader.LoadFadeOut());

        AsyncOperation loader = SceneManager.LoadSceneAsync("MainMenu");
        if (loader == null)
        {
            Debug.LogError("Unable to load scene: Game");
            yield break;
        }

        while (!loader.isDone)
        {
            yield return null;
        }

        Debug.Log("Scene loading complete");
    }

    protected IEnumerator LoadMainGame() {

        yield return new WaitForSecondsRealtime(fader.LoadFadeOut());

        AsyncOperation loader = SceneManager.LoadSceneAsync("AppleCatcher");
        if (loader == null)
        {
            Debug.LogError("Unable to load scene: Game");
            yield break;
        }

        while (!loader.isDone)
        {
            yield return null;
        }

        Debug.Log("Scene loading complete");
    }
    
    public void LoadMenu() {
        StartCoroutine(LoadMainMenu());
    }

    public void LoadGame() {
        StartCoroutine(LoadMainGame());
    }
}
