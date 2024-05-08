using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public float Speed;
    public float DestroyTime;
    public GameObject BlastVFX;

    //maybe onawake is better?
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(BlastVFX,transform.position,Quaternion.identity); 
        Invoke("Destroy", DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale+= new Vector3(Speed, Speed, Speed);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            // do stuff with this
        }
    }
}
