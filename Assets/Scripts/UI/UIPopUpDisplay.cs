using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UIPopUpDisplay : MonoBehaviour
{
    [SerializeField] GameEvent _onPopUpExit;
    //[SerializeField] GameEvent _onPopUpFinished;
    [SerializeField] string[] _phrases;
    [Space]
    [SerializeField] Image _illustrationGameObject;
    [SerializeField] Sprite[] _illustrations;
    [SerializeField] Sprite _blankIllustration;

    private TextMeshProUGUI _TMPtext;
    private int _currentTextIndex = 0;
    private int _currentIllustrationIndex = 0;

    public void SetPhrase() {
        
        //First iteration
        if (_TMPtext == null) _TMPtext = GetComponentInChildren<TextMeshProUGUI>();

        if (_TMPtext != null && _currentTextIndex < _phrases.Length) {

            if (_phrases[_currentTextIndex] == "Exit"){

                _currentTextIndex++;
                _onPopUpExit.Raise();
                return;
            }
            if (_phrases[_currentTextIndex] == "Illustration" && _currentIllustrationIndex < _illustrations.Length){

                GetComponent<UIPopUpFader>().FadeItemIn(_illustrationGameObject.gameObject, 2f);
                _TMPtext.text = "";
                _illustrationGameObject.sprite = _illustrations[_currentIllustrationIndex];
                _currentIllustrationIndex++;
            }
            else {
                GetComponent<UIPopUpFader>().FadeItemIn(_TMPtext.gameObject, 1.5f);
                _TMPtext.text = _phrases[_currentTextIndex];
                _illustrationGameObject.sprite = _blankIllustration;
            }

            _currentTextIndex++;
        }
        else {
            _currentTextIndex = 0;
            _currentIllustrationIndex = 0;

            _onPopUpExit.Raise();
        }
    }

    public void DebugTest(){
        Debug.Log("Click!");
    }
}
