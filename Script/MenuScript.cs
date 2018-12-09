using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScript : MonoBehaviour {
    public Transform title;
    static public GameObject emplois;
    static public GameObject etudes;
    static public GameObject info;
    static public GameObject savoir;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadMenu(Menu[] menuData)
    {
        int posY = 550;
        int posX = 550;
        foreach (Menu menu in menuData)
        {
            if (menu.title != "Tout" && menu.title != "Activites")
            {
                var tab = Instantiate(title);
                tab.transform.parent = gameObject.transform;
            }
        }
        int tabsCount=gameObject.transform.childCount;
        for(int i = 0; i<tabsCount; i++)
        {
            var child= gameObject.transform.GetChild(i); 
            gameObject.transform.GetChild(i).GetChild(0).GetComponent<TextMeshPro>().SetText(menuData[i].title);
            child.position=new Vector3(posX,posY,0);
            child.GetChild(1).GetComponent<TabOnClick>().tabName = menuData[i].title;
            posY = posY - 350;
        }
    }
    static void DisplayBackground(Transform planTransform)
    {
        if (planTransform)
        {
            Transform menu = planTransform.parent.parent;
            foreach (Transform tranformMenu in menu)
            {
                tranformMenu.GetChild(1).localScale = new Vector3(8, 1, 30);
            }
            planTransform.localScale = new Vector3(0, 0, 0);
        }
    }
    static public void SetMenu(string name, Transform planTransform)
    {
        MenuScript.DisplayBackground(planTransform);
        switch (name)
        {
            case "Emploi":
                {
                    ApplyMenu(emplois);
                    break;
                };
            case "Etude":
                {
                    ApplyMenu(etudes);
                    break;
                }
            case "Competences":
                {
                    ApplyMenu(savoir);
                    break;
                };
            default:
                {
                    ApplyMenu(info);
                    break;
                }
        }
    }
    static public void ApplyMenu (GameObject gameObject)
    {
        Vector3 ZeroVector = new Vector3(0, 0, 0);
        emplois.transform.localScale=ZeroVector;
        etudes.transform.localScale=ZeroVector;
        info.transform.localScale=ZeroVector;
        savoir.transform.localScale=ZeroVector;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
    public class Menu
    {
        public string title;
        public string tab;
        public string li;
        public string path;
    }
    public class CV
    {
        public string langue ;
        public string autreLangue ;
        public string titreInfo ;
        public string titreEmplois ;
        public string titreEtudes ;
        public string titreLangues ;
        public string titreCompetences ;
        public string titreDev ;
        public string titreCAO ;
        public string titreArt ;
        public string phraseExplication ;
        public string titreActivites ;
        public string titreExpos ;
        public string titreAssos ;
        public string titreHobbies ;
        public string btnOk ;
        public string btnCancel ;
        public string titreImprimer ;
        public string textImpGros ;
        public string textImpPtt ;
        public string toutSelect ;
        public string titreContact ;
        public string nom ;
        public string placeHolderNom ;
        public string email ;
        public string placeHolderEmail ;
        public string sujet ;
        public string placeHolderSujet ;
        public string message ;
        public string placeHolderMessage ;
        public string btnEnvoyer ;
        public string textSiteWeb ;
        public string siteWeb;
    }
}
