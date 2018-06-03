using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    /* Test Section */

    public Item testItem;

    /* End Test Section */

    private List<Item> itemList;
    private List<Item> displayedItems;

    int maxPages = 1;
    int displayedPage = 1;

    [Space]
    [Header("Don't touch those!")]
    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;


    private List<GameObject> slots; // a list holding every slot

    
    void Start()
    {
        itemList = new List<Item>();
        displayedItems = new List<Item>();

        slots = new List<GameObject>
        {
            slot0,
            slot1,
            slot2,
            slot3,
            slot4,
            slot5,
            slot6,
            slot7
        };
    }

    private void Update()
    {
        /* Test Section */
        if ( Input.GetKeyDown(KeyCode.A))
        {
            AddItem(testItem);
        }
        /* End Test Section */
    }


    private void UpdateSlots()
    {
        
        // Remove all Items from slots and deactivate all slots first
        foreach(GameObject slot in slots)
        {
            slot.GetComponent<ItemConnection>().RemoveItem();
            slot.SetActive(false);
        }

        // Activate needed slots and register the items to be displayed
        for (int i = 0; i < displayedItems.Count; i++)            
        {
            ItemConnection itemConnection = slots[i].GetComponent<ItemConnection>();

            itemConnection.RegisterItem(displayedItems[i]);
            slots[i].transform.GetChild(0).GetComponent<Text>().text = itemConnection.GetName();

            slots[i].SetActive(true);
            
        }
    }

    private void UpdateDisplayedItems()
    {
        displayedItems.Clear();

        int delta = (displayedPage - 1) * 8;

        
        for(int i = 0; i < itemList.Count && i < 8; i++)
        {
            if (i+delta < itemList.Count)
            {
                displayedItems.Add(itemList[i + delta]);
            }
            else
            {
                return;
            }
        }
    }


    public void AddItem(Item itemToAdd)
    {
        itemList.Add(itemToAdd);

        maxPages = (int)Math.Ceiling((double)itemList.Count / 8.0);

        UpdateDisplayedItems();
        UpdateSlots();
    }

    public void RemoveItem(Item itemToRemove)
    {
        itemList.Remove(itemToRemove);

        maxPages = (int)Math.Ceiling((double)itemList.Count / 8.0);

        UpdateDisplayedItems();
        UpdateSlots();
    }

    public void NextPage()
    {
        if (displayedPage == maxPages)
        {
            return;
        }

        displayedPage++;

        UpdateDisplayedItems();
        UpdateSlots();
    }

    public void LastPage()
    {
        if (displayedPage == 1)
        {
            return;
        }
        
        displayedPage--;

        UpdateDisplayedItems();
        UpdateSlots();
    }
}
