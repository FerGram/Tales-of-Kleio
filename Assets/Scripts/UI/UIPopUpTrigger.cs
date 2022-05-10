using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUpTrigger : MonoBehaviour
{
    [SerializeField] GameEvent _onPopUpEnter;

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Player") {
            _onPopUpEnter.Raise();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
