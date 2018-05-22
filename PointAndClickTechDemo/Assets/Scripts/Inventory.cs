using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    /* Test Section */

    public Item testItem;

    /* End Test Section */


    public GameObject itemPrefab;
    public Transform itemsPanelTransform;
    
    private List<GameObject> itemList;


    static int startX = 5;
    static int startY = -5;

    static int itemWidth = 90;
    static int itemHeight = 50;

    static int rows = 2;
    static int collumns = 4;

    
    private class ItemPlus
    {
        GameObject item;

        int xPos;
        int yPos;

        public ItemPlus(GameObject item, int x, int y)
        {
            this.item = item;
            xPos = x;
            yPos = y;
        }
    }

    // Use this for initialization
    void Start()
    {
        itemList = new List<GameObject>();
        
        /* Test Section */

        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);

        /* End Test Section */
    }

    //TODO: Positionierung & Skalierung der Elemente 
    private void OnGUI()
    {        
        int itemsPerSite = rows * collumns;
        for(int n = 0; n < itemsPerSite-1 && n < itemList.Count; n++)
        {
            if(itemList[n] != null)
            {
                GameObject item = itemList[n];

                RectTransform rectTransform = item.GetComponent<RectTransform>();

                if (n > collumns)
                {

                }
                
                rectTransform.position = new Vector3(startX + n * itemWidth, startY - n * itemHeight, 0);
            }            
        }

        /*
        int i = 0;
        foreach (GameObject item in itemList)
        {
            if (i > itemsPerSite - 1)  // Check ob Seite voll, Todo: Seite umblättern & filtern welche items angezeigt werden
            {
                RectTransform rectTransform = item.GetComponent<RectTransform>();

                rectTransform.position = new Vector3(startX + i * itemWidth, startY - i * itemHeight, 0);
            }
            i++;
        }
        */
    }

    /*
    public void AddItem(GameObject itemToAdd)
    {
        itemList.Add(itemToAdd);
    }
    */


    public void AddItem(Item itemToAdd)
    {
        GameObject itemGO = Instantiate(itemPrefab);

        itemGO.transform.SetParent(itemsPanelTransform);

        itemGO.GetComponent<ItemConnection>().RegisterItem(itemToAdd);

        itemList.Add(itemGO);
    }
}
