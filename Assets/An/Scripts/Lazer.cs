using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    //Naming convention man, fix it
    //ref: https://myunity.dev/coding-guideline-for-unity-c/

    //public Camera myCamera;
    public float Speed;
    public GameObject Explotion;
    public Rigidbody laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //maybe it should not be in update, bullet can be curved and stuff which is weird (or cool :D)
        float x = Screen.width / 2;
        float y = Screen.height / 2;
        var ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        laser.velocity = ray.direction * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            UIManager.kill++; //the enemy should have this instead?
            Instantiate(Explotion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
