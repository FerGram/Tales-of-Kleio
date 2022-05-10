using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    // private bool _pressurePlatePressed = false;
    private Vector3 _defaultPos;
    private Vector3 _defaultScale;

    private void Start() {
        _defaultPos = transform.localPosition;
        _defaultScale = transform.localScale;
    }

    public void ActivateFanRotation(){

        transform.LeanRotateY(transform.localEulerAngles.y + 180f, 0.3f).setEaseInOutExpo();
    }
}
