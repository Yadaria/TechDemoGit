using UnityEngine;

public class RightClickDisable : MonoBehaviour {
	
	void Update () {
		if(Input.GetMouseButtonUp(1))
        {
            this.gameObject.SetActive(false);
        }
	}
}
