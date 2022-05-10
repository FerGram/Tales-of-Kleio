using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    void Start()
    {
        transform.LeanMoveLocalY(transform.position.y + 0.1f, 2f).setLoopPingPong().setEaseInOutSine();
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
    }
}
