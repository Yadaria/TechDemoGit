using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Agent3D : MonoBehaviour
{

    NavMeshAgent agent;
    
    public UIActionsController actionsController;   // Wird gebraucht, um die aktuelle action abzufragen

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //no controlls if pointer is over ui
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("tag = " + hit.collider.tag);
                if (hit.collider.tag == "Ground")
                {
                    agent.SetDestination(hit.point);
                }

                if (actionsController.CurrentInteraction == UIActionsController.Interaction.pickUp && hit.collider.tag == "PickUp")
                {
                    hit.collider.gameObject.GetComponent<PickUp>().TakeItem();

                    actionsController.ResetInteraction();
                }

                if(actionsController.CurrentInteraction == UIActionsController.Interaction.talkTo && hit.collider.tag == "Dialogue")
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
