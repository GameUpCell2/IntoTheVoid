using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMotor : MonoBehaviour
{
    public float obstacleSpeed = 10f;
    public GameObject[] explosions; 
    

    private const float xLimit = 17f;
    private const float maxZLimit = 29f;
    private const float minZLimit = -26f;

    public int health = 1;
    public int destructScore = 5;
    private int damages = 0;

    void Update()
    {
        // Move obstacle foward
        if(GameManager.Instance.GameLevel > 0)
        {   
            Vector3 targetPos = transform.position + (Vector3.back * obstacleSpeed * Time.deltaTime * (GameManager.Instance.GameLevel));
            targetPos.y = 0;
            transform.position = targetPos;
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
            damages += 1;
            transform.localScale -= new Vector3(1,1,1);
            if(damages == health)
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
