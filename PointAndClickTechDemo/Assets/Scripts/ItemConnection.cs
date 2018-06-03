using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemConnection : MonoBehaviour
{    
    public Item myItem;

    [Space]
    [Header("Don't touch those!")]
    public UIActionsController actionsController;
    public GameObject lookAtPanel;
    

    public void RegisterItem(Item item)
    {
        myItem = item;
    }

    public void RemoveItem()
    {
        if (myItem != null)
        {
            myItem = null;
        }
    }

    public String GetName()
    {
        return myItem.itemName;
    }

    public void Clicked()
    {        
        switch (actionsController.CurrentInteraction)
        {            
            case UIActionsController.Interaction.lookAt:
                LookAtItem();
                break;
            default:
                break;                
        }

        actionsController.ResetInteraction();
    }

    private void LookAtItem()
    {
        lookAtPanel.transform.GetChild(0).GetComponent<Text>().text = myItem.name;
        lookAtPanel.transform.GetChild(1).GetComponent<Text>().text = myItem.lookAtText;
        lookAtPanel.SetActive(true);
    }




}
