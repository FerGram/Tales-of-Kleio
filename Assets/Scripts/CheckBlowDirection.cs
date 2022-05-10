using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckBlowDirection : MonoBehaviour
{
    [SerializeField] MicrophoneInput microphoneInput;
    [SerializeField] GameEvent _onBlowMic;
    // [SerializeField] float _timeBetweenBlows = 0.4f;

    public static CheckBlowDirection Instance;
    public Vector2 blowDirection;

    // private float _elapsedTime = 0;

    private void Awake() {
        if (Instance == null) Instance = this;
    }

    private void Update()
    {
        if (microphoneInput != null && microphoneInput.activate == true)
        {
            if (IsDirectionLeft(microphoneInput.GetMoveDirectionFromCamera()))
            {
                blowDirection = new Vector2(-1, 0);
            }

            if (IsDirectionRight(microphoneInput.GetMoveDirectionFromCamera()))
            {
                blowDirection = new Vector2(1, 0);
            }

            if (IsDirectionTop(microphoneInput.GetMoveDirectionFromCamera()))
            {
                blowDirection = new Vector2(0, 1);
            }

            if (IsDirectionBottom(microphoneInput.GetMoveDirectionFromCamera()))
            {
                blowDirection = new Vector2(0, -1);
            }

            // _elapsedTime = 0;
            _onBlowMic.Raise();
        }
    }

    private bool IsDirectionLeft(Vector3 direction)
    {
        return direction.x < 0;
    }

    private bool IsDirectionRight(Vector3 direction)
    {
        return direction.x > 0;
    }

    private bool IsDirectionTop(Vector3 direction)
    {
        return direction.z > 0;
    }

    private bool IsDirectionBottom(Vector3 direction)
    {
        return direction.z < 0;
    }
}
