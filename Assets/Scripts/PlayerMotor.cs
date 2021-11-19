using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{   
    public float moveSpeed = 20f;
    public float sensitivity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(InputSystem.Instance.FingerDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, InputSystem.Instance.TargetPos, moveSpeed * sensitivity);
        }
        
    }
}
