using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMotor : MonoBehaviour
{
    public float missileSpeed = 2f;

    void Update()
    {
        transform.position += Vector3.forward * missileSpeed * Time.deltaTime;
    }
}
