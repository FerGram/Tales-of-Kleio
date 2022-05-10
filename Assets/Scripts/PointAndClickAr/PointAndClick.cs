using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private NavMeshAgent Agent;
    [SerializeField]
    private GameObject _touchParticles;

    public Animator character;

    // Update is called once per frame
    void Update()
    {
        //  if (Input.touchCount > 0)
        //  {
        //      Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //      RaycastHit hit;
        //      if (Physics.Raycast(ray, out hit))
        //      {
        //          Debug.Log("point clicked");
        //          if (_touchParticles != null) {
        //              GameObject particles = Instantiate(_touchParticles, hit.point + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
        //              Destroy(particles, 1f);
        //          }
        //          Agent.SetDestination(hit.point);

        //         if (Agent.SetDestination(hit.point))
        //         {
        //             character.SetBool("Running", true);
        //         }
        //         else
        //         {
        //             character.SetBool("Running", false);
        //         }
        //     }
        //  }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("point clicked");
                if (_touchParticles != null) {
                    GameObject particles = Instantiate(_touchParticles, hit.point + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                    Destroy(particles, 1f);
                }

                Agent.SetDestination(hit.point);

                if (Vector3.Distance(Agent.transform.position, hit.point) > 1)
                {
                    character.SetBool("Running", true);
                } else
                {
                    character.SetBool("Running", false);
                }
            }
        }
    }

    public void SetNewAgent(NavMeshAgent newAgent){
        Agent = newAgent;
    }
    public void SetNewAnimator(Animator newAnim){
        character = newAnim;
    }
}
