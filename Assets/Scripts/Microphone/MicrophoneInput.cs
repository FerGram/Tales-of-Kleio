using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity;
    public bool activate;

    private float powSensitivity;

    private Transform camaraTransform;

    private void Awake()
    {
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(null, true, 999, 44100);
            microphoneInitialized = true;
        }

        camaraTransform = GetComponent<Transform>();
    }


    void Update()
    {
        // get mic volume

        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        powSensitivity = Mathf.Pow(sensitivity, 4);

        if (levelMax > powSensitivity && !activate)
        {
            activate = true;
        }

        if (levelMax < powSensitivity && activate)
        {
            activate = false;
        }

    }

    public Vector3 GetMoveDirectionFromCamera()
    {
        Vector3 cameraForward = camaraTransform.forward;
        Vector3 cameraForwardXZplane = new Vector3(cameraForward.x, 0, cameraForward.z);
        Vector3 worldDirectionToMove = Vector3.zero;

        //figuring out if we need to move on z or x axis
        if (Mathf.Abs(cameraForwardXZplane.z) > Mathf.Abs(cameraForwardXZplane.x))
        {
            worldDirectionToMove = cameraForwardXZplane;
            worldDirectionToMove.x = 0;
            worldDirectionToMove = worldDirectionToMove.normalized;
        }
        else
        {
            worldDirectionToMove = cameraForwardXZplane;
            worldDirectionToMove.z = 0;
            worldDirectionToMove = worldDirectionToMove.normalized;
        }

        return worldDirectionToMove;
    }
}
