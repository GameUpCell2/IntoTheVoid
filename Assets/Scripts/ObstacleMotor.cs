using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMotor : MonoBehaviour
{
    public float obstacleSpeed = 2f;
    private float degrees = 35f;
    void Update()
    {
        
        Vector3 to = new Vector3(degrees, 0, 0);
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
        transform.position += Vector3.back * obstacleSpeed * Time.deltaTime;

    }
}
