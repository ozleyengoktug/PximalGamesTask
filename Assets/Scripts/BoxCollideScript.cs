using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollideScript : MonoBehaviour
{
    public static GameObject brokenBox;

    private void Awake()
    {
        //Zaten null de�ilse bo�una i�lem yapmamak i�in
        if(brokenBox == null)
            brokenBox = Resources.Load("Prefabs/BrokenBox") as GameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //K�r�lmay� sa�layabilmek i�in (AddExplosionFoce kullan�labilir)
        if (collision.gameObject.tag == "Obstacle")
        {
            Instantiate(brokenBox, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
