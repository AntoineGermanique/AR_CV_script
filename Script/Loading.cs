using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using System.Reflection;

public class Loading : MonoBehaviour
{
    public string url = "http://localhost:3000/";
    public Hashtable routes = new Hashtable() {
        { "info", typeof(InfoScript.Info) },
        { "emplois", typeof(EmploisScript.Emploi[]) },
        { "etudes", typeof(EtudesScript.Etude[]) },
        { "savoir", typeof(SavoirScript.Savoir[]) },
        { "menu", typeof(MenuScript.Menu[])}
    };
    public Hashtable objects = new Hashtable();
    public ArrayList CVObjects = new ArrayList();
    // Use this for initialization
    void Start()
    {
        foreach (DictionaryEntry pair in routes)
        {
            Type type = pair.Value as Type;
            StartCoroutine(GetObjectJson(pair.Key as string, url, type));
        }
    }
    void LoadMesh()
    {
        InfoScript.Info infoData = objects["info"] as InfoScript.Info;
        GameObject.FindGameObjectWithTag("info").GetComponent<InfoScript>().LoadInfo(infoData);
        MenuScript.Menu[] menuData = objects["menu"] as MenuScript.Menu[];
        GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuScript>().LoadMenu(menuData);
        EmploisScript.Emploi[] emploisData = objects["emplois"] as EmploisScript.Emploi[];
        GameObject.FindGameObjectWithTag("Emplois").GetComponent<EmploisScript>().LoadEmplois(emploisData);
        EtudesScript.Etude[] etudesData = objects["etudes"] as EtudesScript.Etude[];
        GameObject.FindGameObjectWithTag("Etudes").GetComponent<EtudesScript>().LoadEtudes(etudesData);
        SavoirScript.Savoir[] savoirData = objects["savoir"] as SavoirScript.Savoir[];
        GameObject.FindGameObjectWithTag("Savoir").GetComponent<SavoirScript>().LoadSavoir(savoirData);
        MenuScript.SetMenu("",null);
    }


    IEnumerator GetObjectJson(string route, string url, Type type)
    {
        UnityWebRequest www = UnityWebRequest.Get(url + "/fr/" + route);
        www.SetRequestHeader("origin", "http://localhost:8080");
        www.SetRequestHeader("content-type", "json");
        yield return www.Send();

        var myObject = JsonConvert.DeserializeObject(www.downloadHandler.text, type);
        objects.Add(route, myObject);
        if (objects.Count == routes.Count)
        {
            LoadMesh();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
