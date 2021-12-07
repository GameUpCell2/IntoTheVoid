using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMotor : MonoBehaviour
{
    private float missileSpeed = 6f;
    private const float xLimit = 17f;
    private const float maxZLimit = 29f;
    private const float minZLimit = -26f;

    void Update()
    {
        if(GameManager.Instance.GameLevel > 0)
        {
            transform.position += Vector3.forward * missileSpeed * Time.deltaTime ;    
        }
        else
        {
            transform.position += Vector3.forward * missileSpeed * Time.deltaTime;
        }

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
