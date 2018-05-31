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
    private List<GameObject> displayedItems;
    
    int maxPages = 1;
    int displayedPage = 1;

    static int startX = 5;
    static int startY = -5;

    static int itemWidth = 90;
    static int itemHeight = 50;
        

    // Use this for initialization
    void Start()
    {
        itemList = new List<GameObject>();
        displayedItems = new List<GameObject>();

        /* Test Section */

        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);
        AddItem(testItem);

        /* End Test Section */
        ArangeItems();

    }
    

    
    private void ArangeItems()
    {
        int coloumn = 0;

        for (int i = 0; i < itemList.Count; i++)
        {            
            RectTransform rectTransform = itemList[i].GetComponent<RectTransform>();

            Vector3 position = new Vector3(0,0,0);

            if (i < 4)  // first Row
            {
                int deltaX = coloumn * itemWidth;
                position.x += startX + deltaX;
                position = new Vector3(startX + deltaX, startY, 0);


            }
            else // second Row
            {
                int deltaX = coloumn * itemWidth;
                position = new Vector3(startX + deltaX, startY - itemHeight, 0);
               
            }

            coloumn++;
            if (coloumn == 4)
            {
                coloumn = 0;
            }

            Debug.Log(position);
            rectTransform.localPosition = position;

        }
    }
    

    public void AddItem(Item itemToAdd)
    {
        GameObject itemGO = Instantiate(itemPrefab);
        

        itemGO.transform.SetParent(itemsPanelTransform, false);

        itemGO.GetComponent<ItemConnection>().RegisterItem(itemToAdd);

        itemList.Add(itemGO);
    }

    public void NextPage()
    {
        if (displayedPage == maxPages)
        {
            return;
        }
        //TODO

    }

    public void LastPage()
    {
        if(displayedPage == 1)
        {
            return;
        }
        //TODO

    }
}
