using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavoirScript : MonoBehaviour {
    public Transform prefab;

    // Use this for initialization
    public void LoadSavoir(Savoir[] savoirData )
    {
        CleanPrefab();
        foreach (Savoir savoir in savoirData)
        {
            SetText(GetSavoirLevel(GetSavoirCategorie(savoir), savoir),savoir);
        }
        var savoirPrefab = Object.Instantiate(prefab);
        savoirPrefab.transform.parent = gameObject.transform;
        MenuScript.savoir = gameObject;
    }
    GameObject GetSavoirCategorie(Savoir savoir)
    {
        switch (savoir.categorie) {
            case "1":
                {
                    return prefab.GetChild(0).gameObject;
                }
            case "2":
                {
                    return prefab.GetChild(1).gameObject;
                }
            case "3":
                {
                    return prefab.GetChild(2).gameObject;
                }
            default:return new GameObject();
        }

    }
    GameObject GetSavoirLevel(GameObject category, Savoir savoir)
    {
        switch (savoir.etoile)
        {
            case "1":
                {
                    return category.transform.GetChild(2).GetChild(2).gameObject;
                }
            case "2":
                {
                    return category.transform.GetChild(2).GetChild(1).gameObject;
                }
            case "3":
                {
                    return category.transform.GetChild(2).GetChild(0).gameObject;
                }
            default: return new GameObject();
        }
    }
    void CleanPrefab()
    {
        for (var i = 0; i < 3; i++) {
            for (var j = 0; j < 3; j++)
            {
                prefab.GetChild(i).GetChild(2).GetChild(j).GetChild(2).GetComponent<TextMeshPro>().text="";

            }
        }
}
    void SetText(GameObject level, Savoir savoir)
    {
        level.transform.GetChild(2).gameObject.GetComponent<TextMeshPro>().text += FormatText(savoir.savoir);
    }
    string FormatText(string text)
    {
        return " |<mark=#00000022>" + text + "</mark>| ";
    }
    void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}
        public class Savoir
    {
        public string savoir;
        public string details;
        public string etoile;
        public string categorie;
    }
}
