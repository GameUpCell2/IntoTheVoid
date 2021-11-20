using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMotor : MonoBehaviour
{
    public float missileSpeed = 2f;
    private const float xLimit = 10f;
    private const float maxZLimit = 15f;
    private const float minZLimit = -15f;

    void Update()
    {
        transform.position += Vector3.forward * missileSpeed * Time.deltaTime;
        DestroyOutOfBounds();
    }

    private void DestroyOutOfBounds()
    {   

        if(transform.position.x > xLimit)
        {
            Destroy(gameObject);
        }

        if(transform.position.x < -xLimit)
        {
            Destroy(gameObject);
        }

        if(transform.position.z > maxZLimit)
        {
            Destroy(gameObject);
        }

        if(transform.position.z < minZLimit)
        {
            Destroy(gameObject);
        }
    }
}
