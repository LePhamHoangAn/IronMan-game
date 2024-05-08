using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Naming convention man, fix it
    //ref: https://myunity.dev/coding-guideline-for-unity-c/
    public GameObject arCamera;
    public GameObject Crosshair;
    public GameObject EnemyUI;

    public Image Swipe;
    public Image Release;

    public float speed;

    public Text Elimination;
    static public int kill;


    // Start is called before the first frame update
    void Start()
    {
        Swipe.fillAmount = 1;
        Release.fillAmount = 1;


    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(arCamera.transform.position,arCamera.transform.forward,out hit))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                EnemyUI.gameObject.SetActive(true); 
                Crosshair.transform.localScale -= new Vector3(speed, speed, speed);
            }
        }
        else
        {
            EnemyUI.gameObject.SetActive(false);

            Crosshair.transform.localScale += new Vector3(speed, speed, speed);

        }

        if(Crosshair.transform.localScale.x<=1)
        {
            Crosshair.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Crosshair.transform.localScale.x >= 2)
        {
            Crosshair.transform.localScale = new Vector3(2, 2, 2);
        }


        //this cooldown UI does not work, WHY?
        if(Shooting.isLazer)
        {
            Release.fillAmount = 0;
        }
        if(Release.fillAmount == 0)
        {
            Release.fillAmount+=1/Shooting.LazerCooldownTime*Time.deltaTime;
            if(Release.fillAmount>=1)
            {
                Release.fillAmount=1;
            }
        }

        if (Shooting.isBlast)
        {
            Swipe.fillAmount = 0;
        }
        if (Swipe.fillAmount == 0)
        {
            Swipe.fillAmount += 1 / Shooting.BlastCooldownTime * Time.deltaTime;
            if (Swipe.fillAmount >= 1)
            {
                Swipe.fillAmount = 1;
            }
        }

        Elimination.text = "Eliminations: " + kill;

    }
}
