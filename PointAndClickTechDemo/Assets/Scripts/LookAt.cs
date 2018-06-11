using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAt : MonoBehaviour
{
    public GameObject lookAtPanel;

    public string objectName;
    [TextArea(3, 10)]
    public string text;

    public void LookAtObject()
    {
        lookAtPanel.transform.GetChild(0).GetComponent<Text>().text = objectName;
        lookAtPanel.transform.GetChild(1).GetComponent<Text>().text = text;
        lookAtPanel.SetActive(true);

        if (objectName == "Grabstein")
        {
            GameManager.graveVisited = true;
        }
    }
}
