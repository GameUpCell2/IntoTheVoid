using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private const float xLimit = 5.5f;
    private const float zLimit = 0.0f;
    private const float moveSpeed = 2f;
    
    private void Start()
    {

    }

    private void Update()
    {
        if(MobileInput.Instance.SwipeLeft)
        {
            // Move to the left
            MovePosition(1, true);
        }

        if(MobileInput.Instance.SwipeRight)
        {
            // Move to the right
            MovePosition(-1, true);
        }

        if(MobileInput.Instance.SwipeUp)
        {
            // Move forward
            MovePosition(1, false);
        }
        
        if(MobileInput.Instance.SwipeDown)
        {
            // Move forward
            MovePosition(-1, false);
        }
        
        KeepWithinBounds();
    }

    private void MovePosition(int direction, bool horizontal)
    {   // -1 = Right, +1 = Left
        // Vector3 targetPosition;
        switch(direction){
            case -1: 
                if(horizontal) // Go Right
                {
                    if(transform.position.x > -xLimit || true)
                    {
                        Vector3 movement = Vector3.right * moveSpeed;
                        transform.position += movement;
                    }
                }
                else // Go Backward
                {
                    {
                        Vector3 movement = - Vector3.forward * moveSpeed;
                        transform.position += movement;
                    }
                } 
                break;
            
            
            case 1:
                if(horizontal) // Go Left
                {
                    if(transform.position.x > -xLimit || true)
                    {
                        Vector3 movement = - Vector3.right * moveSpeed;
                        transform.position += movement;
                    }
                }
                else // Go forward
                {
                    {
                        Vector3 movement = Vector3.forward * moveSpeed;
                        transform.position += movement;
                    }
                } 
                break;
        }       
    }

    
    private void KeepWithinBounds()
    {
        if(transform.position.x >= xLimit){
            Debug.Log("You went out of bounds");
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }

        if(transform.position.x <= -xLimit){
            Debug.Log("You went out of bounds");
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }

        if(transform.position.z >= zLimit){
            Debug.Log("You went out of bounds");
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
    }
}
