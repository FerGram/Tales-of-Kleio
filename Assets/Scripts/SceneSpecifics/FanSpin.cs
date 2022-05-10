using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] int _fanSpins = 5;
    [SerializeField] ParticleSystem _blowParticles;

    public void BlowFan()
    {
        Vector2 blowDir = CheckBlowDirection.Instance.blowDirection;
        Vector3 blowDirXYZ = new Vector3(blowDir.x, 0, blowDir.y);

        if (blowDirXYZ == -transform.forward) {
            transform.LeanRotateAroundLocal(Vector3.forward, 360 * _fanSpins, 3f).setEaseOutCirc();
            if (_blowParticles != null) _blowParticles.Play();
        }
    }
}
