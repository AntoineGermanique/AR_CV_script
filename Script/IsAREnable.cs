using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAREnable : MonoBehaviour {
    public GameObject container;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.GetComponent<MeshRenderer>().enabled)
        {
            container.GetComponent<ARAdjustement>().enabled = true;
        }
        else
        {
            container.GetComponent<ARAdjustement>().enabled = false;
            container.GetComponent<ARAdjustement>().refresh = true;
        }
    }
}
