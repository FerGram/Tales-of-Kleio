using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetector : MonoBehaviour
{
    [SerializeField] GameEvent _onDoorEnter;

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Key") {

            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);

            // Destroy(other.gameObject);
            // Destroy(gameObject);
        }
    }
}
