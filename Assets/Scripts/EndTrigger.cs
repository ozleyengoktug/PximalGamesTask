using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public static bool isFinished = false;
    const string animLetsKick = "LetsKick";
    const string dance = "Dance";
    public Transform BoxParent;
    public Transform newPosToObjParent;
    static int whichNewPos;
    float objTranslateSpeed = 2f;
    private bool gameOver = false;

    private void OnTriggerEnter(Collider collision)
    {
        //Bitiþe gelmiþ ise ve tek sefer çalýþmasý için
        if (collision.tag == "FinishLine" && !isFinished)
        {
            isFinished = true;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            CharacterMovementScript.speed = 0;
            FinishGame();
        }
    }

    //Tekmelemeye baþlamasý için
    private void FinishGame()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool(animLetsKick, true);
    }

    //Vecto3.Lerp ile yapýcaktým fakat daha önce kullanmadýðým için sorunlar çýktý.
    public void ObjectToTruck()
    {
        if (!gameOver)
        {
            BoxParent.GetChild(0).position = newPosToObjParent.GetChild(whichNewPos).position;
            //BoxParent.GetChild(0).position = Vector3.Lerp(BoxParent.GetChild(0).position, newPosToObjParent.GetChild(whichNewPos).position, Time.deltaTime * objTranslateSpeed);
            BoxParent.GetChild(0).parent = null;
            whichNewPos++;
        }
    }

    private void Update()
    {
        // Oyun Bitmiþ Ýse Yani Tüm Kutularý Tekmelediyse Dans
        if (BoxParent.childCount == 0 && isFinished) 
        {
            gameOver = true;
            Animator animator = GetComponent<Animator>();
            animator.SetBool(dance, true);
        }
    }
}
