using System;
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

    public float interactionRadius = 1.0f;
    private bool isOnItsWay = false;

    

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
                //Debug.Log("tag = " + hit.collider.tag);
                if (hit.collider.tag == "Ground")
                {
                    agent.SetDestination(hit.point);                    
                } else
                {
                    if (actionsController.CurrentInteraction == UIActionsController.Interaction.pickUp && hit.collider.tag == "PickUp")
                    {
                        itemToPickUp = hit.collider.gameObject.GetComponent<PickUp>();

                        toExecute += ExecutePickUp;                        
                    }

<<<<<<< HEAD
                    if (actionsController.CurrentInteraction == UIActionsController.Interaction.talkTo && hit.collider.tag == "Dialogue")
                    {
                        toExecute += ExecuteTalkTo;
                    }

                    if(toExecute != null)
                    {
                        GetInInteractionRange(hit.point, toExecute);

                        actionsController.ResetInteraction();
                    }                                        
=======
                if (actionsController.CurrentInteraction == UIActionsController.Interaction.talkTo && hit.collider.tag == "Dialogue")
                {
                    SceneManager.LoadScene("Dialogue");
                }

                if (actionsController.CurrentInteraction == UIActionsController.Interaction.goTo && hit.collider.tag == "Exit")
                {
                    if (hit.collider.GetComponent<ExitScene>() == null)
                    {
                        Debug.Log("ExitScene Component is missing.");
                        return;
                    }
                    hit.collider.GetComponent<ExitScene>().LoadNextScene();
                }

                if (actionsController.CurrentInteraction == UIActionsController.Interaction.lookAt && hit.collider.tag == "Observable")
                {
                    hit.collider.GetComponent<LookAt>().LookAtObject();
                }

                if (actionsController.CurrentInteraction == UIActionsController.Interaction.lookAt && hit.collider.tag == "Cupboard")
                {
                    SceneManager.LoadScene("Tafel");
>>>>>>> 9b7ff28b015e254c56d42514b79110631a6fd980
                }
            }
        }
    }

    #region Interactions Stuff

    /// <summary>
    /// Die Action bei der die Methoden angemeldet werden, die je nach Click-Ziel Ausgeführt werden sollen.
    /// </summary>
    Action toExecute;

    /// <summary>
    /// Merkt sich das Item, welches aufgehoben wird, nachdem der Raycast der Maus 
    /// </summary>
    PickUp itemToPickUp;

    private void ExecutePickUp()
    {
        itemToPickUp.TakeItem();

        //Reset
        actionsController.ResetInteraction();
        toExecute -= ExecutePickUp;
    }

    private void ExecuteTalkTo()
    {
        SceneManager.LoadScene(1);

        toExecute -= ExecuteTalkTo;
    }

    #endregion

    private void GetInInteractionRange(Vector3 point, Action toExecute)
    {
        //Debug.Log("GetInInteractionRange(Vector3 point, Action toExecute)");

        agent.SetDestination(point);
        StartCoroutine(StopAndExecuteWhenInRange(toExecute));
    }

    private IEnumerator StopAndExecuteWhenInRange(Action toExecute)
    {
        //Debug.Log("StopAndExecuteWhenInRange(Action toExecute)");

        float distance = float.MaxValue;
        while (distance > interactionRadius)
        {
           distance= Vector3.Distance(agent.destination, this.transform.position);
            yield return null;
        }
        agent.SetDestination(transform.position);

        toExecute();
        //Debug.Log("End of StopAndExecuteWhenInRange(Action toExecute)");
    }
}
