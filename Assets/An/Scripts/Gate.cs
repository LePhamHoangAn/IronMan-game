using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    //Naming convention man, fix it
    //ref: https://myunity.dev/coding-guideline-for-unity-c/

    public float skrinkSpeed;
    private bool isSkrink=false;
    // Start is called before the first frame update
    void OnEnable()
    {
        //make the varible public or serialize bro, how lazy r u
        Invoke("SetSkrink", 9f);
        Invoke("DestroyGO", 11f);
    }

    //shrink not skrink
    void SetSkrink()
    {
        isSkrink = true;
    }

    void DestroyGO()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //print(isSkrink);
        if (isSkrink)
        {
            
            this.gameObject.transform.localScale -= new Vector3(skrinkSpeed, skrinkSpeed, skrinkSpeed);
            float clampSize = Mathf.Clamp(this.gameObject.transform.localScale.x, 0, Mathf.Infinity);
            this.gameObject.transform.localScale = new Vector3(clampSize, clampSize, clampSize);
        }
    }
}
