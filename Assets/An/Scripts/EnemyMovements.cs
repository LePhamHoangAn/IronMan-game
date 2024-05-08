using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    private GameObject Target;
    public float Speed;
    public GameObject Explotion;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        float speed = Speed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed);
        transform.LookAt(Target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Blast")
        {
            Instantiate(Explotion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
