using UnityEngine;

using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Drag : MonoBehaviour
{
    private Vector3 screenPoint; private Vector3 offset; private float _lockedYPosition;
    public float max = 2500;
    public float min = 700;
    void OnMouseDown()
    {
        //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.localPosition); // I removed this line to prevent centring 
        _lockedYPosition = Camera.main.nearClipPlane;
        offset = transform.localPosition- new Vector3(0, Input.mousePosition.y, 0);



    }

    void OnMouseDrag()
    {
        if (transform.localPosition.y < max && transform.localPosition.y > min)
        {
            Vector3 curScreenPoint = new Vector3(transform.localPosition.x, Input.mousePosition.y, transform.localPosition.z);
            Vector3 curPosition = curScreenPoint + new Vector3(0, offset.y, 0);
            //curPosition.x = _lockedYPosition;
            transform.localPosition = curPosition;
            Debug.Log(offset.y);
            Debug.Log(transform.localPosition.y);
        }
    }
    void OnMouseUp()
    {
        if (transform.localPosition.y < min)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, min + 1, transform.localPosition.z);
        }
        else if (transform.localPosition.y > max)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, max - 1, transform.localPosition.z);
        }
    }

}