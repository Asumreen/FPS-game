using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLogic : MonoBehaviour {
    public static int currTouch = 0;

	// Use this for initialization
	void Start () {
        if(Input.touches.Length<=0)	{

        }
        else{
            for (int i = 0; i < Input.touchCount;i++){
                currTouch = 0;
                if(GetComponent<GUITexture>()!=null&&(GetComponent<GUITexture>().HitTest(Input.GetTouch(i).position))){
                    if(Input.GetTouch(i).phase==TouchPhase.Began){
                        SendMessage("OnTouchBegan");
                    }
                    if(Input.GetTouch(i).phase==TouchPhase.Ended){
                        SendMessage("OnTouchEnded");
                    }
                    if(Input.GetTouch(i).phase==TouchPhase.Moved){
                        SendMessage("OnTouchMoved");
                    }
                }
                if(Input.GetTouch(i).phase==TouchPhase.Began){
                    SendMessage("OnTouchBehanAnyware");
                }
                if(Input.GetTouch(i).phase==TouchPhase.Ended){
                    SendMessage("OnTouchEndedAnyware");
                }
                if(Input.GetTouch(i).phase==TouchPhase.Moved){
                    SendMessage("OnTouchMovedAnyware");
                }
                if(Input.GetTouch(i).phase==TouchPhase.Stationary){
                    SendMessage("OnTouchStayedAnyware");
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
