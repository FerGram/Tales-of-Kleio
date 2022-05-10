using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCam : MonoBehaviour
{
    public float ease=0.1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        float mult = Mathf.Clamp(Time.deltaTime / 0.016f, 0, 1/ease); // our ease factor is for 60Hz
        target.position = transform.position * (ease * mult) + target.position * (1-ease * mult);
        target.rotation = Quaternion.Lerp(transform.rotation,target.rotation,1-ease * mult);
    }
}
