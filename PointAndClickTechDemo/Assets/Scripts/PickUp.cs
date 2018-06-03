using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{
    

    public Item pickedUpItem;

    [Space]
    [Header("Don't touch those!")]
    public Inventory inventory;
    



    public void TakeItem()
    {
        inventory.AddItem(pickedUpItem);
        Destroy(this.gameObject);
    }

}
