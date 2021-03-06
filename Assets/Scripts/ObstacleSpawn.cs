using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class ObstacleSpawn : MonoBehaviour
{
    public static ObstacleSpawn Instance {set; get;}
    public float spawnRate = 0.5f;
    public bool isSpawning = true;
    private const float xLimit = 9f;
    private const float laneWidth = 4f;
    public GameObject[] astroids;

    private Vector3 lastSpawnPos;
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
                yield return new WaitForSeconds(spawnRate / (GameManager.Instance.GameLevel * 3));
            }
            else
            {
                yield return new WaitForSeconds(spawnRate);
            }

        }
        

    }

    private void SpawnNewObstacle()
    {
        int randMult = Random.Range (1, GameManager.Instance.GameLevel);
        int randIndx = Random.Range (0, astroids.Length);
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
        if(spawnLocation == lastSpawnPos)
        {   
            lane = (float)randomRange * spawnLawn;
            spawnLocation = new Vector3(lane, 0, transform.position.z);
        }

        GameObject go = Instantiate(randomObs, spawnLocation, Quaternion.identity);
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
