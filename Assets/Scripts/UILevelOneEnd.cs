using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelOneEnd : MonoBehaviour
{
    [SerializeField] GameEvent _onLevelOneEnded;
    public GameObject level1CompletedPanel;

    public void Start()
    {
        level1CompletedPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _onLevelOneEnded.Raise();
            Invoke("LevelOneEnded", 2f);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void LevelOneEnded()
    {
        level1CompletedPanel.SetActive(true);

    }
}
