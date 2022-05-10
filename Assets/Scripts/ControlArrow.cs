using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlArrow : MonoBehaviour
{
    [SerializeField]
    Rope rope;
    [SerializeField]
    GameObject ArrowDown;
    [SerializeField]
    GameObject ArrowUp;

    private void Start()
    {
        changeArrow();
    }
    public void changeArrow()
    {
        if (rope.Get_isUp())
        {
            ArrowUp.active = false;
            ArrowDown.active = true;
        }

        else
        {
            ArrowUp.active = true;
            ArrowDown.active = false;
        }
    }
}
