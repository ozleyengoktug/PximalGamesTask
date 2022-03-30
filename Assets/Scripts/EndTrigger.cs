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
        //Biti�e gelmi� ise ve tek sefer �al��mas� i�in
        if (collision.tag == "FinishLine" && !isFinished)
        {
            isFinished = true;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            CharacterMovementScript.speed = 0;
            FinishGame();
        }
    }

    //Tekmelemeye ba�lamas� i�in
    private void FinishGame()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool(animLetsKick, true);
    }

    //Vecto3.Lerp ile yap�cakt�m fakat daha �nce kullanmad���m i�in sorunlar ��kt�.
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
        // Oyun Bitmi� �se Yani T�m Kutular� Tekmelediyse Dans
        if (BoxParent.childCount == 0 && isFinished) 
        {
            gameOver = true;
            Animator animator = GetComponent<Animator>();
            animator.SetBool(dance, true);
        }
    }
}
