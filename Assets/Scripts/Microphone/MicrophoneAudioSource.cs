using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the usage of the microphone to be used as an audio source clip for
/// real-time audio analysis.
/// </summary>
public class MicrophoneAudioSource : MonoBehaviour {
	public AudioSource audioSource;
	public string microphoneName;
	public bool listMicrophones = false;

	// Start is called before the first frame update
	void Start() {
		// List the available microphones to pick one.
		if (listMicrophones) {
			for (int i = 0; i < Microphone.devices.Length; i++) {
				Debug.Log(Microphone.devices[i]);
			}
		}

		// Grab our own audio source component if needed.
		if (audioSource == null)
			audioSource = GetComponent<AudioSource>();

		// Setup the microphone as a real-time audio input.
		//audioSource.clip = Microphone.Start(microphoneName, true, 10, 44100);
		audioSource.clip = Microphone.Start(null, true, 10, 44100);
		audioSource.loop = true;
		while (!(Microphone.GetPosition(microphoneName) > 0))
        {
			//Debug.Log("Detecting sound");
			audioSource.Play();
		}
	}

    private void Update()
    {
        
    }
}
