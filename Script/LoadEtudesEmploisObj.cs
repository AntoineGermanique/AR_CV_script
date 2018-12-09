using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

static public class LoadEtudesEmploisObj  {

    static public void LoadEmploisEtudes<T>(T[] data, GameObject gameObject, Transform prefab)
    {
        int posY = 550;
        int posX = -500;
        foreach (T menu in data)
        {

            var tab = Object.Instantiate(prefab);
            tab.transform.parent = gameObject.transform;
        }
        int itemsCount = gameObject.transform.childCount;
        for (int i = 0; i < itemsCount; i++)
        {
            var item = gameObject.transform.GetChild(i);
            //var texts = gameObject.transform.GetComponents<TextMeshPro>();
            foreach (var property in data[i].GetType().GetFields())
            {
                for (int j = 0; j < item.transform.childCount; j++)
                {
                    if (property.Name == item.GetChild(j).name)
                    {
                        item.GetChild(j).GetComponent<TextMeshPro>().SetText(property.GetValue(data[i]) as string);
                    }
                }
            }
            item.position = new Vector3(posX, posY, 0);
            posY = posY - 250;
        }
    }
}
