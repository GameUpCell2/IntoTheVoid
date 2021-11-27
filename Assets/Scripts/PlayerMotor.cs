using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{   
    private float moveSpeed = 1f;
    public float sensitivity;
    private const float xLimit = 15f;
    private const float maxZLimit = 25f;
    private const float minZLimit = -25f;
    // Start is called before the first frame update
    void Start()
    {
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if(!GameManager.Instance.IsPaused  && InputSystem.Instance.FingerDown)
        {   
            transform.position = Vector3.MoveTowards(transform.position, InputSystem.Instance.TargetPos, moveSpeed * sensitivity);
        }
        PlayerArsenal.Instance.LaunchMissile(transform.position);
        KeepWithinBounds();    
    }

    private void KeepWithinBounds()
    {   
        Vector3 targetPos;

        if(transform.position.x > xLimit)
        {
            targetPos = transform.position;
            targetPos.x = xLimit;
            transform.position = targetPos;
        }

        if(transform.position.x < -xLimit)
        {
            targetPos = transform.position;
            targetPos.x = -xLimit;
            transform.position = targetPos;
        }

        if(transform.position.z > maxZLimit)
        {
            targetPos = transform.position;
            targetPos.z = maxZLimit;
            transform.position = targetPos;
        }

        if(transform.position.z < minZLimit)
        {
            targetPos = transform.position;
            targetPos.z = minZLimit;
            transform.position = targetPos;
        }
    }

    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Player");

        if(other.gameObject.tag == "Enemy")
        {   
            Debug.Log("GameOver!");
            GameManager.Instance.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
            

        }

    }
}
