using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform target;
    public float zOffset = 0;
    public float xOffset = 0;
    public float rotationOffset = 0;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.localPosition = new Vector3(target.localPosition.x + xOffset, target.localPosition.z + yOffset, zPosition);
        transform.position = new Vector3(target.position.x + xOffset, transform.position.y, target.position.z + zOffset);

        //transform.Rotate(Vector3.forward, angle);

        float angle = 360.0f  - target.rotation.eulerAngles.y + rotationOffset;
        transform.rotation = Quaternion.Euler(90, 0, angle);
        
    }
}
