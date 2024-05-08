using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float ShootCooldown;
    public GameObject HomingRocket;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(ShootCooldown);

            Instantiate(HomingRocket,transform.position,Quaternion.identity);

        StartCoroutine(Spawn());
    }
}
