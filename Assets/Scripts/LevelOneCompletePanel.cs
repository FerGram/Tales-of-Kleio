using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOneCompletePanel : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider progressBar;
    public string nextScene;
    public GameObject LevelCompletePanel;

    private void Start()
    {
        LevelCompletePanel.SetActive(false);
    }

    public void NextLevel()
    {
        LevelCompletePanel.SetActive(false);
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
}
