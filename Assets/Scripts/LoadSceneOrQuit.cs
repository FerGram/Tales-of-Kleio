using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneOrQuit : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject storyPanel;
    public GameObject mainScreenPanel;
    public Slider progressBar;

    public string nextScene;

    private void Start()
    {
        LoadingScreen.SetActive(false);
        storyPanel.SetActive(false);
    }

    public void LoadingScene()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        AsyncOperation loadGame = SceneManager.LoadSceneAsync(nextScene);

        LoadingScreen.SetActive(true);

        while (!loadGame.isDone)
        {
            float progress = Mathf.Clamp01(loadGame.progress / 0.9f);
            progressBar.value = progress;
            yield return null;
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void Story()
    {
        storyPanel.SetActive(true);
        mainScreenPanel.SetActive(false);
    }
}
