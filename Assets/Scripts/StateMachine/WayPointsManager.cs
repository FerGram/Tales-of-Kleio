using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsManager : MonoBehaviour
{
    //Contains list of transforms for the player to move through 

    [SerializeField] private List<Transform> posPoints = new List<Transform>();


    //GetWayPointIndex checks which is the current way point index to continue the path
    public Transform GetWayPointIndex(int index)
    {
        if (index >= posPoints.Count)
            return null;

        return posPoints[index];
    }

    //IsIndexValid retuns the current index of the point in the list
    public bool IsIndexValid(int index)
    {
        return index < posPoints.Count && index >= 0;
    }
}
