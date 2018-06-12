using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Agent3D : MonoBehaviour
{

    NavMeshAgent agent;

    public UIActionsController actionsController;   // Wird gebraucht, um die aktuelle action abzufragen

    public float interactionRadius = 1.0f;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Die Action bei der die Methoden angemeldet werden, die je nach Click-Ziel Ausgeführt werden sollen.
    /// </summary>
  

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
                objectClickedOn = hit.collider.gameObject;

                //Debug.Log("tag = " + hit.collider.tag);
                if (hit.collider.tag == "Ground")
                {
                    agent.SetDestination(hit.point);
                }
                else
                {
                    if (actionsController.CurrentInteraction == UIActionsController.Interaction.pickUp && hit.collider.tag == "PickUp")
                    {
                        
                        //itemToPickUp = hit.collider.gameObject.GetComponent<PickUp>();

                        toExecute += ExecutePickUp;
                    }

                    if (actionsController.CurrentInteraction == UIActionsController.Interaction.talkTo && hit.collider.tag == "Dialogue")
                    {
                        toExecute += ExecuteTalkTo;
                    }                    

                    if (actionsController.CurrentInteraction == UIActionsController.Interaction.goTo && hit.collider.tag == "Exit")
                    {
                        /*
                        if (hit.collider.GetComponent<ExitScene>() == null)
                        {
                            Debug.Log("ExitScene Component is missing.");
                            return;
                        }
                        hit.collider.GetComponent<ExitScene>().LoadNextScene();
                        */
                        toExecute += ExecuteGoTo;
                    }

                    if (actionsController.CurrentInteraction == UIActionsController.Interaction.lookAt && hit.collider.tag == "Observable")
                    {
                        toExecute += ExecuteLookAt;

                        //hit.collider.GetComponent<LookAt>().LookAtObject();
                    }

                    if (actionsController.CurrentInteraction == UIActionsController.Interaction.lookAt && hit.collider.tag == "Cupboard")
                    {
                        SceneManager.LoadScene("Tafel");
                    }


                    if (toExecute != null)
                    {
                        GetInInteractionrangeAndInteract(hit.point, toExecute);

                        actionsController.ResetInteraction();
                    }
                }
            }
        }
    }

    #region Interactions Stuff

    Action toExecute;

    GameObject objectClickedOn;

    void ExecuteGoTo()
    {
        ExitScene exit = objectClickedOn.GetComponent<ExitScene>();
        if (exit == null)
        {
            Debug.Log("ExitScene Component is missing.");
            return;
        }
        exit.LoadNextScene();
    }

    void ExecuteLookAt()
    {
        objectClickedOn.GetComponent<LookAt>().LookAtObject();
        
        toExecute -= ExecuteLookAt;
    }

    void ExecutePickUp()
    {
        objectClickedOn.GetComponent<PickUp>().TakeItem();
        //itemToPickUp.TakeItem();        
        toExecute -= ExecutePickUp;
    }

    void ExecuteTalkTo()
    {
        SceneManager.LoadScene("Dialogue");

        toExecute -= ExecuteTalkTo;
    }

    #endregion

    private void GetInInteractionrangeAndInteract(Vector3 point, Action toExecute)
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
            distance = Vector3.Distance(agent.destination, this.transform.position);
            yield return null;
        }
        agent.SetDestination(transform.position);

        toExecute();
        //Debug.Log("End of StopAndExecuteWhenInRange(Action toExecute)");
    }
}
