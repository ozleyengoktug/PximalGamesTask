using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public static float speed = 4f;
    public float swerveSpeed;
    Vector3 firstPos,endPos;
    public float min,max;
    public bool firstTouch;
    Animator animator;
    const string animRun = "Run";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Bitiþ çizgisine gelmemiþ ise
        if (!EndTrigger.isFinished)
        {
            // Haritayý tersten dizaynladýðým için += yerine -= kullanmak zorunda kaldým
            //Ýlk týklamayla birlikte sürekli hareket eder
            if (firstTouch) transform.position -= Vector3.forward * speed * Time.deltaTime; 
            if (Input.touchCount > 0)
            {
                //Oyun tekrar baþlayýnca firstTouch = false 
                if (!firstTouch)
                {
                    animator.SetBool(animRun, true);
                    firstTouch = true;
                }

                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                    firstPos = touch.position;
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    Swerving(touch.position);
            }

            // Haritadan taþmamak için.
            float xPos = Mathf.Clamp(transform.position.x, min, max);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }

    //Hyper-casual oyun yapmadým. Ýnternetten birkaç araþtýrmayla bulabildiðim buydu.
    private void Swerving(Vector2 touch)
    {
        endPos = touch;
        float diff = endPos.x - firstPos.x;
        transform.Translate(diff * Time.deltaTime * swerveSpeed, 0, 0);
    }
}
