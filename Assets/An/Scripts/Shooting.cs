using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //Naming convention man, fix it
    //ref: https://myunity.dev/coding-guideline-for-unity-c/


    //public Image Swipe;
    //public Image Release;

    public GameObject Rocket;
    public GameObject Lazer;
    public GameObject Blast;
    public GameObject Hand;

    static public float BlastCooldownTime=10;
    static public float LazerCooldownTime=1;

    [HideInInspector]
    private bool isRocket;
    static public bool isBlast;
    static public bool isLazer;
    static public bool isBlastcooldown;
    static public bool isLazercooldown;
    private bool isCharging;

    private bool canBlast;
    private bool canLazer;


    // Start is called before the first frame update
    void Start()
    {
        canBlast = true;
        canLazer = true;
        //Swipe.fillAmount = 1;
        //Release.fillAmount = 1;
        UIManager.kill = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger==ManoGestureTrigger.CLICK)
        {
            isRocket = true;
        }
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger == ManoGestureTrigger.SWIPE_UP&&canBlast)
        {
            isBlast = true;
            canBlast = false;
            StartCoroutine(BlastCooldown());
        }
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger == ManoGestureTrigger.RELEASE_GESTURE&&canLazer)
        {
            isLazer = true;
            canLazer = false;
            StartCoroutine(LazerCooldown());

        }
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger == ManoGestureTrigger.GRAB_GESTURE)
        {
            isLazer = false;

        }


        if(isRocket)
        {
            Instantiate(Rocket, Hand.transform.position, Quaternion.identity);

            isRocket = false;
        }
        if(isBlast)
        {
            Instantiate(Blast, Hand.transform.position, Quaternion.identity);
            //Swipe.fillAmount = 0;

            isBlast = false;

        }
        if(isLazer)
        {
            Instantiate(Lazer, Hand.transform.position, Quaternion.identity);
            //Release.fillAmount = 0;
            isLazer =false;
        }

        //if (isLazercooldown)
        //{
        //    Release.fillAmount += 1 / LazerCooldownTime * Time.deltaTime;
        //    if (Release.fillAmount >= 1)
        //    {
        //        Release.fillAmount = 1;
        //    }
        //}

        //if (isBlastcooldown)
        //{
        //    Swipe.fillAmount += 1 / BlastCooldownTime * Time.deltaTime;
        //    if (Swipe.fillAmount >= 1)
        //    {
        //        Swipe.fillAmount = 1;
        //    }
        //}

    }

    IEnumerator BlastCooldown()
    {
        isBlastcooldown = true;
        yield return new WaitForSeconds(BlastCooldownTime);
        canBlast = true;
        isBlastcooldown=false;
    }
    IEnumerator LazerCooldown()
    {
        isLazercooldown = true;
        yield return new WaitForSeconds(LazerCooldownTime);
        canLazer = true;
        isLazercooldown=false;
    }
}
