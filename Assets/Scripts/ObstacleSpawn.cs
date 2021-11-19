using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public float spawnRate = 1f;
    private bool isSpawning = true;
    public bool IsSpawning {get {return isSpawning; }}
    private const float xLimit = 10f;
    public GameObject firstObs;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());        
    }
    
    IEnumerator SpawnObstacles()
    {
        while(isSpawning)
        {
            SpawnNewObstacle();
            yield return new WaitForSeconds(spawnRate);
        }
        

    }

    private void SpawnNewObstacle()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-xLimit, xLimit), 0, transform.position.z);
        Instantiate(firstObs, spawnLocation, Quaternion.identity);
    }
}
