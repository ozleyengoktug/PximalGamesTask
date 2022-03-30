using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollideScript : MonoBehaviour
{
    public static GameObject brokenBox;

    private void Awake()
    {
        //Zaten null deðilse boþuna iþlem yapmamak için
        if(brokenBox == null)
            brokenBox = Resources.Load("Prefabs/BrokenBox") as GameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Kýrýlmayý saðlayabilmek için (AddExplosionFoce kullanýlabilir)
        if (collision.gameObject.tag == "Obstacle")
        {
            Instantiate(brokenBox, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
