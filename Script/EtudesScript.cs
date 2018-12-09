using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtudesScript : MonoBehaviour {
    public Transform prefab;
    public void LoadEtudes(Etude[] etudesData)
    {
        LoadEtudesEmploisObj.LoadEmploisEtudes(etudesData, gameObject, prefab);
        MenuScript.etudes = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public class Etude : EmploisScript.Emploi { }

}
