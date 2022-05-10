using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private LayerMask FloorLayers;
    [SerializeField]
    private NavMeshAgent Agent;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            //Debug.Log("point clicked");
            if (Physics.Raycast(Camera.ScreenPointToRay(Input.mousePosition), out RaycastHit Hit))
            {
                Debug.Log("point clicked");
                Agent.SetDestination(Hit.point);
            }
        }
    }
}