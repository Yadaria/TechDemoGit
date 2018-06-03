using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisWhenDestroyed : MonoBehaviour {

    public GameObject toDestroy;

    private void OnDestroy()
    {
        Destroy(toDestroy);
    }
}
