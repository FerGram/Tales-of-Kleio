using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPopUpFader : MonoBehaviour
{
    [SerializeField] [Range(0f, 3f)] float _fadeInTime;
    [SerializeField] [Range(0f, 3f)] float _fadeOutTime;

    private GameObject[] _children;

    private void Start() {

        _children = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _children[i] = transform.GetChild(i).gameObject;
            SetAlpha(_children[i], 0f);
            _children[i].SetActive(false);
        }
    }

    public void FadeChildrenIn(){

        for (int i = 0; i < transform.childCount; i++)
        {
            _children[i] = transform.GetChild(i).gameObject;
            StartCoroutine(FadeAlphaIn(_children[i], 1f));
        }
    }

    public void FadeChildrenOut(){
        
        for (int i = 0; i < transform.childCount; i++)
        {
            _children[i] = transform.GetChild(i).gameObject;
            StartCoroutine(FadeAlphaOut(_children[i], 1f));
        }
    }

    public void FadeItemIn(GameObject item){
        StartCoroutine(FadeAlphaIn(item, _fadeInTime));
    }
    public void FadeItemIn(GameObject item, float fadeTime){
        StartCoroutine(FadeAlphaIn(item, fadeTime));
    }
    public void FadeItemOut(GameObject item, float fadeTime){
        StartCoroutine(FadeAlphaOut(item, fadeTime));
    }

    private void SetAlpha(GameObject item, float alphaAmount){

        //Try if it has either an Image (button and BG) or Text component
        Image image = item.GetComponent<Image>();
        TextMeshProUGUI text = item.GetComponent<TextMeshProUGUI>();

        if (image != null)
        {
            Color color = image.color;
            color.a = alphaAmount;
            image.color = color;
        }
        if (text != null) text.alpha = alphaAmount;
    }
    IEnumerator FadeAlphaIn(GameObject item, float fadeTime){

        item.SetActive(true);

        //Try if it has either an Image (button and BG) or Text component
        Image image = item.GetComponent<Image>();
        TextMeshProUGUI text = item.GetComponent<TextMeshProUGUI>();

        float elapsedTime = 0;

        while (elapsedTime < fadeTime){

            if (image != null)
            {
                Color color = image.color;
                color.a = elapsedTime / fadeTime;
                image.color = color;
            }
            if (text != null) text.alpha = elapsedTime / fadeTime;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator FadeAlphaOut(GameObject item, float fadeTime){

        //Try if it has either an Image (button and BG) or Text component
        Image image = item.GetComponent<Image>();
        TextMeshProUGUI text = item.GetComponent<TextMeshProUGUI>();

        float elapsedTime = 0;
        
        while (elapsedTime < fadeTime){

            if (image != null)
            {
                Color color = image.color;
                color.a = 1f - (elapsedTime / fadeTime);
                image.color = color;
            }
            if (text != null) text.alpha = 1f - elapsedTime / fadeTime;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        item.SetActive(false);
    }
}
