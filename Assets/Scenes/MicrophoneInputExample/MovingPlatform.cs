using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float stopDistance = 0.1f;
    public GameObject leftDestination;
    public GameObject rightDestination;

    public void MoveLeft()
    {
        if(Vector3.Distance(transform.position, leftDestination.transform.position) >= stopDistance)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        if (Vector3.Distance(transform.position, rightDestination.transform.position) >= stopDistance)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
