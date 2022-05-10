using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void OpenDoor(){

        Debug.Log("Door UP");
        Destroy(gameObject);

        // transform.LeanRotateY(transform.rotation.eulerAngles.y + 115f, 0.5f).setEaseOutElastic();
        // GetComponent<BoxCollider>().enabled = false;
    }
}
