using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToStack : MonoBehaviour
{
    public Transform BoxesParent;

    private void OnTriggerEnter(Collider collision)
    {
        //Stack'e ekleme
        if (collision.tag == "Box")
        {
            collision.transform.parent = BoxesParent;
            collision.transform.localPosition = new Vector3(0, (BoxesParent.childCount - 1) * BoxesParent.GetChild(0).transform.localScale.y, 0);
        }
    }
}
