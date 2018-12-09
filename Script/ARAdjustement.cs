using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAdjustement : MonoBehaviour {
    //public float posX = -0.35431f;
    //public float posY = -7.0749f;
    //public float posZ = -13.008f;
    //public float scale = 0.006535703f;
    public Vector3 position = new Vector3(1.62f, -3.88f, 3.32f);
    public float scale = 0.005f;
    public float rotation = 90;
    public bool refresh = true;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = position;
        transform.localScale = new Vector3(scale, scale, scale);
        if (transform.GetComponent<ARAdjustement>().enabled && refresh)
        {
            transform.rotation = Quaternion.Euler(rotation, 0, 0);
            refresh = false;
        }
    }
}
