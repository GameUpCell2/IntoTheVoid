using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveTimer : MonoBehaviour
{
    private Image timerCircle;
    private float timeOutSecs = 0.005f; // 5 seconds
    
    void Start()
    {
        timerCircle = gameObject.GetComponent<Image>();    
    }

    
    void FixedUpdate()
    {
        timerCircle.fillAmount -= timeOutSecs;
        if (timerCircle.fillAmount <= 0.0f)
        {
            GameManager.Instance.UseReviveAd(false);
        } 
    }
}
