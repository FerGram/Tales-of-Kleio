using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameEvent _onPressurePlatePressed;
    // [SerializeField] GameEvent _onPressurePlateLeft;

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Player"){
            LeanTween.moveY(gameObject, transform.position.y - 0.05f, 0.3f).setEaseOutBack();
            _onPressurePlatePressed.Raise();
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if (other.tag == "Player"){
            LeanTween.moveY(gameObject, transform.position.y + 0.05f, 0.3f).setEaseOutBack();
        }
    }

}
