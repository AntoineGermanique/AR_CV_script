using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void LoadInfo(Info infoData)
    {
        MenuScript.info = gameObject;
        List<string> textInfoArray = new List<string>();
        var temp = typeof(Info).GetFields();
        foreach (var propertyInfo in infoData.GetType().GetFields())
        {
            var key = propertyInfo;
            textInfoArray.Add(EnrichText(propertyInfo.GetValue(infoData) as string, propertyInfo.Name));
        }
        GameObject Info = GameObject.FindGameObjectWithTag("info");
        TextMeshPro textMeshPro = Info.GetComponent<TextMeshPro>();
        string text = FormatText(textInfoArray);
        textMeshPro.SetText(text);
    }
    string EnrichText(string line, string name)
    {
        switch (name)
        {
            case "nom":
            case "prenom":
                return "<size=130%>" + line;
            case "cv":
                return "<size=300%>" + line;
            default:
                return "<size=100%>" + line;
        }
    }

    string FormatText(List<string> strings)
    {
        string text = "";
        foreach (string line in strings)
        {
            text += line + "\r\n";
        }
        return text;
    }
    // Update is called once per frame
    void Update () {
		
	}
    public class Info
    {
        public string nom;
        public string prenom;
        public string cv;
        public string titre;
        public string site;
        public string tel;
        public string mail;
    }
}

