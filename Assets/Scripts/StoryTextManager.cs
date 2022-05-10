using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryTextManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    public GameObject continueButton;


    public GameObject LoadingScreen;
    public Slider progressBar;

    public string nextScene;

    public void Start()
    {
        LoadingScreen.SetActive(false);
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    public void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            StartCoroutine(LoadNextScene());
        }
    }

    public void Skip()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(2);

        AsyncOperation loadGame = SceneManager.LoadSceneAsync(nextScene);

        while (!loadGame.isDone)
        {
            float progress = Mathf.Clamp01(loadGame.progress / 0.5f);
            progressBar.value = progress;
            yield return null;
        }
    }

}
