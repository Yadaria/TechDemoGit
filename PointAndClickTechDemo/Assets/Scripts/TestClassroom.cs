using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClassroom : MonoBehaviour {
    public GameObject test;
	// Use this for initialization
	void Start () {
        if (UICupboard.isAnswerCorrect)
        {
            test.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            test.SetActive(false);
        }
	}
}
