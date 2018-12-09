using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabOnClick : MonoBehaviour {
    public string tabName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                MenuScript.SetMenu(tabName, transform);
            }
        }
    }

}
