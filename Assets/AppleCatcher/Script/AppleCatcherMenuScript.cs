using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleCatcherMenuScript : MonoBehaviour
{
    [SerializeField]
    protected WhiteFader fader;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(LoadMainGame());
        }
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
            float progress = Mathf.Clamp01(loader.progress / 0.9f); // Normalize progress between 0 and 1
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            yield return null;
        }

        Debug.Log("Scene loading complete");
    }
}
