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
    public int gunNumber = 2;
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
            allowFire = false;
            GameObject firstMissile = allMissiles[0];
            
            Vector3 leftGunPosition = new Vector3(playerPosition.x - gunDistance, playerPosition.y, playerPosition.z);
            Vector3 rightGunPosition = new Vector3(playerPosition.x + gunDistance, playerPosition.y, playerPosition.z);
            
            Instantiate(firstMissile, playerPosition, Quaternion.identity);    // Center Gun Barrel
            for (int i = 0; i < gunNumber; i++)
            {
                
                Instantiate(firstMissile, leftGunPosition, Quaternion.identity); 
                Instantiate(firstMissile, rightGunPosition, Quaternion.identity);    
                leftGunPosition = new Vector3(leftGunPosition.x - gunDistance, leftGunPosition.y, leftGunPosition.z);
                rightGunPosition = new Vector3(rightGunPosition.x + gunDistance, rightGunPosition.y, rightGunPosition.z);

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
