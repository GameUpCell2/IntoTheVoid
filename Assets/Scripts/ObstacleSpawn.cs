using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class ObstacleSpawn : MonoBehaviour
{
    public static ObstacleSpawn Instance {set; get;}
    public float spawnRate = 2.0f;
    public bool isSpawning = true;
    private const float xLimit = 10f;
    private const float laneWidth = 4f;
    public GameObject[] astroids;

    // PathCreator pathToUse;
    private void Awake()
    {
    	Instance = this;   
    }

    private void Start()
    {
        StartCoroutine(SpawnObstacles());        
    }
    
    void FixedUpdate()
    {
        
    }
    IEnumerator SpawnObstacles()
    {
        while(isSpawning)
        {
            SpawnNewObstacle();
            if(GameManager.Instance.GameLevel > 0)
            {
                yield return new WaitForSeconds(spawnRate / (GameManager.Instance.GameLevel * 2));
            }
            else
            {
                yield return new WaitForSeconds(spawnRate);
            }

        }
        

    }

    private void SpawnNewObstacle()
    {
        int randIndx = Random.Range (0, astroids.Length-1);
        GameObject randomObs = astroids[randIndx];
        int randomRange = Random.Range(0,4);
        float spawnLawn;
        if(Random.value <= 0.5f)
        {
            spawnLawn = -laneWidth;
        }
        else
        {
            spawnLawn = laneWidth;
        }
        float lane = (float)randomRange * spawnLawn;
        Vector3 spawnLocation = new Vector3(lane, 0, transform.position.z);
        Instantiate(randomObs, spawnLocation, Quaternion.identity);
    }

    // private void SpawnNewObstacle()
    // {
        
    //     if(pathToUse != null)
    //     {
    //         var pf = Instantiate(firstObs, new Vector3(0,0,26), Quaternion.identity);
    //         pf.pathCreator = pathToUse;
    //     }
        
    // }
}
