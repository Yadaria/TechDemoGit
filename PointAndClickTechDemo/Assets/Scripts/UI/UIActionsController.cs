using UnityEngine;
using UnityEngine.Events;

public class UIActionsController : MonoBehaviour
{

    public enum Interaction { none, give, pickUp, push, open, lookAt, pull, close, talkTo, use };

    private Interaction currentInteraction = Interaction.none;
    public Interaction CurrentInteraction
    {
        private set { }

        get
        {
            return currentInteraction;
        }
    }


    public void Start()
    {        
    }

    public void ResetInteraction()
    {
        currentInteraction = Interaction.none;        
    }


    // aktuell ungenutzt, vielleicht später...
    public UnityAction giveAction;
    public UnityAction openAction;
    public UnityAction closeAction;
    public UnityAction pickUpAction;
    public UnityAction lookAtAction;
    public UnityAction talkToAction;
    public UnityAction pushAction;
    public UnityAction pullAction;
    public UnityAction useAction;
    

    public void OnClick(int interaction)
    {        
        Debug.Log((Interaction)interaction);

        switch ((Interaction)interaction)
        {
            case Interaction.give:
                currentInteraction = Interaction.give;
                if (giveAction != null)
                    giveAction();
                break;
            case Interaction.pickUp:
                currentInteraction = Interaction.pickUp;
                if (pickUpAction != null)
                    pickUpAction();
                break;
            case Interaction.push:
                currentInteraction = Interaction.push;
                if (pushAction != null)
                    pushAction();
                break;
            case Interaction.open:
                currentInteraction = Interaction.open;
                if (openAction != null)
                    openAction();
                break;
            case Interaction.lookAt:
                currentInteraction = Interaction.lookAt;
                if (lookAtAction != null)
                    lookAtAction();
                break;
            case Interaction.pull:
                currentInteraction = Interaction.pull;
                if (pullAction != null)
                    pullAction();
                break;
            case Interaction.close:
                currentInteraction = Interaction.close;
                if (closeAction != null)
                    closeAction();
                break;
            case Interaction.talkTo:
                currentInteraction = Interaction.talkTo;
                if (talkToAction != null)
                    talkToAction();
                break;
            case Interaction.use:
                currentInteraction = Interaction.use;
                if (useAction != null)
                    useAction();
                break;
        }
    }


}
