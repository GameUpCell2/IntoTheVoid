using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance {set; get;}
    public bool OverGameObject {set; get;}
    private Vector2 startPos;
    private const float pixelDistToDetect = 20f;
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool fingerDown;
    public bool FingerDown {get {return fingerDown;} }
    public bool SwipeUp {get {return swipeUp;} }
    public bool SwipeDown {get {return swipeDown;}}
    public bool SwipeLeft {get {return swipeLeft;}}
    public bool SwipeRight {get {return swipeRight;}}

    private Vector3 targetPos;
    public Vector3 TargetPos {get {return targetPos;}}

    private void Awake(){
    	Instance = this;
        OverGameObject = false;
    }

    private void Update()
    {   
        targetPos = Vector3.zero;
        OverGameObject = false;

        #region Standalone Input
        if(fingerDown && Input.GetMouseButtonUp(0))
            {
                fingerDown = false;
            }
        if (!fingerDown && Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                fingerDown = true;
            }
        if (fingerDown)
        {   
            if(EventSystem.current.IsPointerOverGameObject())
                OverGameObject = true;
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.y = 0;
        }
        #endregion

        #region Mobile Input
        if(Input.touches.Length != 0)
        {
            if(fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                if(EventSystem.current.IsPointerOverGameObject())
                    OverGameObject = true;
                fingerDown = true;
            }
            

            if(fingerDown)
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPos.y = 0;
            }

            if(fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                fingerDown = false;
            }
        }
        #endregion
    
    }
}   

