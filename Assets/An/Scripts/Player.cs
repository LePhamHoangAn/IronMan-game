using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Naming convention man, fix it
    //ref: https://myunity.dev/coding-guideline-for-unity-c/
    public Transform m_NextPoint;
    Quaternion m_MyQuaternion;
    float m_Speed = 1.0f;

    private Vector3 infrontofcam;
    void Start()
    {
        m_MyQuaternion = new Quaternion();
    }

    void Update()
    {
        //The rotation does not work with the main camera, how does the ar camera move?

        infrontofcam = Camera.main.transform.position+ Camera.main.transform.forward;
        //Set the Quaternion rotation from the GameObject's position to the next GameObject's position
        m_MyQuaternion.SetFromToRotation(transform.position, infrontofcam);
        //Move the GameObject towards the second GameObject
        //transform.position = Vector3.Lerp(transform.position, m_NextPoint.position, m_Speed * Time.deltaTime);
        //Rotate the GameObject towards the second GameObject
        transform.rotation = m_MyQuaternion * transform.rotation;
    }
}
