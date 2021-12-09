using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoomIn : MonoBehaviour
{

    public  GameObject tracker;
    public float threshold = 20;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(tracker.transform.position.x, 0, -30f);
    }

    // Update is called once per frame
    void Update()
    {
        bool preparing = Mathf.Abs(transform.position.z - tracker.transform.position.z) > 15f;
        if (preparing)
        {
            Vector3 trackerVector = tracker.transform.position;
            trackerVector.y = 0;
            transform.position = Vector3.Lerp(transform.position, trackerVector, Time.deltaTime * .2f);
        }
        PlayerArsenal.Instance.canAttack = !preparing;

    }


}
