using UnityEngine;
using UnityEngine.Events;

public class UIActionsController : MonoBehaviour
{
    public UnityAction giveAction;

    public void OnGiveClick()
    {
        Debug.Log("OnGiveClick()");

        if (giveAction != null)
            giveAction();
    }

    public UnityAction openAction;

    public void OnOpenClick()
    {
        Debug.Log("OnOpenClick()");

        if (openAction != null)
            openAction();
    }

    public UnityAction closeAction;

    public void OnCloseClick()
    {
        Debug.Log("OnCloseClick()");

        if (closeAction != null)
            closeAction();
    }

    public UnityAction pickUpAction;

    public void OnPickUpClick()
    {
        Debug.Log("OnPickUpClick()");

        if (pickUpAction != null)
            pickUpAction();
    }

    public UnityAction lookAtAction;

    public void OnLookAtClick()
    {
        Debug.Log("OnLookAtClick()");

        if (lookAtAction != null)
            lookAtAction();
    }

    public UnityAction talkToAction;

    public void OnTalkToClick()
    {
        Debug.Log("OnTalkToClick()");

        if (talkToAction != null)
            talkToAction();
    }

    public UnityAction pushAction;

    public void OnPushClick()
    {
        Debug.Log("OnPushClick()");

        if (pushAction != null)
            pushAction();
    }

    public UnityAction pullAction;

    public void OnPullClick()
    {
        Debug.Log("OnPullClick()");

        if (pullAction != null)
            pullAction();
    }

    public UnityAction useAction;

    public void OnUseClick()
    {
        Debug.Log("OnUseClick()");

        if (useAction != null)
            useAction();
    }


}
