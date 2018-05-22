using System;
using UnityEngine;

public class ItemConnection : MonoBehaviour{

    Item myItem;
    
    public void RegisterItem(Item item)
    {
        myItem = item;
    }

    public String GetName()
    {
        return myItem.itemName;
    }


    
}
