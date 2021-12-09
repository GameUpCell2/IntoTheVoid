using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMotor : MonoBehaviour
{
    public float obstacleSpeed = 2f;
    public GameObject[] explosions; 
    public int destructScore = 5;

    private const float xLimit = 17f;
    private const float maxZLimit = 29f;
    private const float minZLimit = -26f;

    private void Start()
    {
        obstacleSpeed = Random.Range(2, 16);
    }


    void Update()
    {
        // Move obstacle foward
        if(GameManager.Instance.GameLevel > 0)
        {
            transform.position += Vector3.back * obstacleSpeed * Time.deltaTime * (GameManager.Instance.GameLevel);
        }
        else
        {
            transform.position += Vector3.back * obstacleSpeed * Time.deltaTime;
        }
        
        DestroyOutOfBounds();

    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("You Hit Something");

        if(other.gameObject.tag == "Missile")
        {   
            Debug.Log("You destroyed a meteor!");
            
            int randIndx = Random.Range (0, explosions.Length-1);
            GameObject randomObs = explosions[randIndx];
            
            Instantiate(randomObs, transform.position, Quaternion.identity);
            
            GameManager.Instance.UpdateScore(destructScore); 
            MyAudioManager.Instance.Play("explosion");
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

        if(transform.position.z < minZLimit)
        {
            Destroy(gameObject);
        }
    }

}
