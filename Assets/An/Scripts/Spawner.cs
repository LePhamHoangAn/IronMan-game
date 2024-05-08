using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Naming convention man, fix it
    //ref: https://myunity.dev/coding-guideline-for-unity-c/

    public Transform[] SpawnPoint;
    public GameObject[] Enemy;
    public GameObject[] Gate;
    private List<Vector3> GatePos=new List<Vector3>();  //List Usage
    public float SpawnCooldown;
    public float Offset;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        //Whack, design better game stages
        if(UIManager.kill>15)
        {
            SpawnCooldown = 4;
        }
        if (UIManager.kill>60)
        {
            SpawnCooldown = 3;
        }
        if (UIManager.kill > 100)
        {
            SpawnCooldown = 2;
        }

    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnCooldown);

        for(int i=0;i<SpawnPoint.Length;i++)
        {
            GameObject gate = Instantiate(Gate[i], SpawnPoint[i].position + new Vector3(Random.Range(-Offset, Offset), Random.Range(-Offset, Offset), Random.Range(-Offset, Offset)), Quaternion.identity);
            GatePos.Add(gate.transform.position);
        }
        yield return new WaitForSeconds(SpawnCooldown);

        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            GameObject enemy = Instantiate(Enemy[i], GatePos[i], Quaternion.identity);
        }

        GatePos.Clear();
        StartCoroutine(Spawn());
    }
}
