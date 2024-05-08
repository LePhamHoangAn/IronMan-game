using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    private GameObject Target;
    public GameObject Explotion;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Enemy");
        Invoke("Destroy", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //update the ai on this
        //ref: https://www.youtube.com/watch?v=Z6qBeuN-H1M 
        float speed = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed);
        transform.rotation = Quaternion.LookRotation(transform.position - Target.transform.position);
        StartCoroutine(CheckMoving());
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(Explotion,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    //super whack, delete this once the ai is updated
    private IEnumerator CheckMoving()
    {
        Vector3 startPos = transform.position;
        yield return new WaitForSeconds(0.1f);
        Vector3 finalPos = transform.position;

        if (startPos.x == finalPos.x || startPos.y == finalPos.y
            || startPos.z == finalPos.z)
        {
            Destroy(this.gameObject);

        }

    }
}
