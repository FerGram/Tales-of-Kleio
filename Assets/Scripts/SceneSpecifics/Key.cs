using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    [SerializeField] float _followSpeed = 1f;
    [SerializeField] float _offsetToPlayer = 1f;
    [Space]
    [SerializeField] AudioClip _pickedUpClip;

    private bool _followPlayer = false;
    private Rigidbody _rb;
    private Transform _player;

    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_followPlayer && Vector3.Distance(transform.position, _player.position) > _offsetToPlayer){
            _rb.velocity = transform.forward * _followSpeed;
            transform.LookAt(_player);
        }
        else if (_followPlayer) _rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other) {
        
        if (!_followPlayer && other.tag == "Player") { 
            _followPlayer = true;
            _player = other.transform;

            //TODO Remove or change place
            AudioSource audioSource = FindObjectOfType<AudioSource>();
            Debug.Log(audioSource);
            if (audioSource != null) audioSource.PlayOneShot(_pickedUpClip);
        }
    }

    //Response for onDoorOpen gameEvent
    public void EnterKeyInDoor(){

        Destroy(gameObject);
    }
}
