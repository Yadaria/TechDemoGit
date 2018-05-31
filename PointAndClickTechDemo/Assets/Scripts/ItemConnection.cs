using System;
using UnityEngine;

public class ItemConnection : MonoBehaviour{

    public Item myItem;
    
    public void RegisterItem(Item item)
    {
        myItem = item;
    }

    public String GetName()
    {
        return myItem.itemName;
    }


    
}
