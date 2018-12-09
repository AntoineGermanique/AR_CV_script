using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmploisScript : MonoBehaviour {
    public Transform prefab;
    public void LoadEmplois(Emploi[] emploisData)
    {
        LoadEtudesEmploisObj.LoadEmploisEtudes(emploisData, gameObject, prefab);
        MenuScript.emplois = gameObject;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public class Emploi
    {
        public string periode1;
        public string periode2;
        public string poste;
        public string entreprise;
        public string lieu;
        public string emplois;
        public bool showDescription;
    }
}
