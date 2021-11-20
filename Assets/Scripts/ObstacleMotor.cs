using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMotor : MonoBehaviour
{
    public float obstacleSpeed = 2f;
    private float degrees = 35f;
    public GameObject obstacleExplosion; 

    private const float xLimit = 10f;
    private const float maxZLimit = 15f;
    private const float minZLimit = -20f;

    void Update()
    {
        // Move obstacle foward
        Vector3 to = new Vector3(degrees, 0, 0);
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
        transform.position += Vector3.back * obstacleSpeed * Time.deltaTime;

        DestroyOutOfBounds();

    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("You Hit Something");

        if(other.gameObject.tag == "Missile")
        {   
            Debug.Log("You destroyed a meteor!");
            // Instantiate(obstacleExplosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);

        }

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

        // if(transform.position.z > maxZLimit)
        // {
        //     Destroy(gameObject);
        // }

        if(transform.position.z < minZLimit)
        {
            Destroy(gameObject);
        }
    }

}
