using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMoveCharacter : MonoBehaviour
{
    [SerializeField] Transform _rope;
    [SerializeField] List<Transform> player=new List<Transform>();
    [SerializeField] Transform _platform;
    [SerializeField] Transform _upPos;
    [SerializeField] Transform _downPos;
    [SerializeField] [Range(0f, 20f)] float _topOffset;
    [SerializeField] [Range(0f, 5f)] float _timeToMove;
    [Space]
    [SerializeField] Transform _fan;
    [Space]
    [SerializeField] ParticleSystem _platformDropParticles;

    private bool _isUp;

    private void Start()
    {
        if (Vector3.Distance(_upPos.position, _platform.position) < 0.2f) _isUp = true;
        else _isUp = false;
    }

    public void MovePlatform()
    {

        if (_rope != null && LeanTween.isTweening(_rope.gameObject)) return;
        if (_platform != null && LeanTween.isTweening(_platform.gameObject)) return;

        Vector2 blowDir = CheckBlowDirection.Instance.blowDirection;
        Vector3 blowDirXYZ = new Vector3(blowDir.x, 0, blowDir.y);

        //Blow in the direction of the fan closes the Cage.
        if (_isUp && blowDirXYZ == _fan.forward) MovePlatformDown();
        else if (!_isUp && blowDirXYZ == -_fan.forward) MovePlatformUp();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player.Add(other.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            player.Remove(other.transform);
    }

    private void MovePlatformUp()
    {
        if (_rope != null) _rope.LeanScaleY(_rope.position.y - _upPos.position.y - _topOffset, _timeToMove).setEaseOutCirc();
        _platform.LeanMove(_upPos.position, _timeToMove).setEaseOutCirc();

        for (int i = 0; i < player.Count; i++)
            player[i].LeanMove(_upPos.position, _timeToMove).setEaseOutCirc();

            _isUp = true;
    }

    private void MovePlatformDown()
    {
        if (_rope != null) _rope.LeanScaleY(_rope.position.y - _downPos.position.y - _topOffset, _timeToMove).setEaseOutCirc();

        for (int i = 0; i < player.Count; i++)
            player[i].LeanMove(_downPos.position, _timeToMove).setEaseOutCirc();

        _platform.LeanMove(_downPos.position, _timeToMove).setEaseOutCirc();
        if (_platformDropParticles != null) _platformDropParticles.Play();
        _isUp = false;
    }
}
