using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform target;
    public float zPosition = 0;
    public float xOffset = 0;
    public float yOffset = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(target.localPosition.x + xOffset, target.localPosition.z + yOffset, zPosition);
	}
}
