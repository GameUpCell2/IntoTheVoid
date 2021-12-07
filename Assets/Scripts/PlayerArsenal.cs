using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArsenal : MonoBehaviour
{
    public GameObject[] allMissiles;
    public static PlayerArsenal Instance {set; get;}
    private float fireRate = 1f;
    private bool allowFire = true;
    
    public float shipWidth = 10f;
    // public int GameManager.Instance.GameScore = 2;
    private float gunDistance = 1.0f;

    private void Awake(){
    	Instance = this;
    }
    
    private void Update()
    {
        
    }
 

    public void LaunchMissile(Vector3 playerPosition)
    {   
        if(allowFire)
        {   
            MyAudioManager.Instance.Play("gun");
            Vector3 spawnPosition = playerPosition;
            spawnPosition.z += 5f;
            allowFire = false;
            GameObject firstMissile = allMissiles[0];
            float gunOffset = -1f;
            Vector3 leftGunPosition = new Vector3(spawnPosition.x - gunDistance, spawnPosition.y, spawnPosition.z + gunOffset);
            Vector3 rightGunPosition = new Vector3(spawnPosition.x + gunDistance, spawnPosition.y, spawnPosition.z + gunOffset);
            
            Instantiate(firstMissile, spawnPosition, firstMissile.transform.rotation);    // Center Gun Barrel
            for (int i = 0; i < GameManager.Instance.GameLevel; i++)
            {
                
                Instantiate(firstMissile, leftGunPosition, firstMissile.transform.rotation); 
                Instantiate(firstMissile, rightGunPosition, firstMissile.transform.rotation);    
                leftGunPosition = new Vector3(leftGunPosition.x - gunDistance, leftGunPosition.y, leftGunPosition.z + gunOffset);
                rightGunPosition = new Vector3(rightGunPosition.x + gunDistance, rightGunPosition.y, rightGunPosition.z + gunOffset);

            }
            
            StartCoroutine(ReloadFire());
        }
        

    }

    IEnumerator ReloadFire()
    {
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }
}
