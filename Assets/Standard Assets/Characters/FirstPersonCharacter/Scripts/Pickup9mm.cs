using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Pickup9mm : MonoBehaviour {
    float theDistance;
    public Text pickText;
    //public GameObject fakeGun;
    public GameObject realGun;
    public GameObject ammoDisplay;
    public string gunName="";
    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCast.DistanceFromTarget;
        if (PlayerCast.target!=null&& PlayerCast.target.name== this.name)
        {
            if (theDistance < 2)
            {
                if (CrossPlatformInputManager.GetButtonDown("open"))
                {
                    TakeNineMil();
                    pickText.text = "";
                    gamecontroller.ins.pickupGun(realGun);
                    return;
                }
                pickText.text = "Take" + gunName;
            }
            else
            {
                pickText.text = "";
            }
        }
        if(theDistance>2){
            pickText.text = "";
        }
    }
    void TakeNineMil(){

        gameObject.SetActive(false);
        realGun.gameObject.SetActive(true);
        ammoDisplay.gameObject.SetActive(true);
       
    }
  /*  private void OnMouseOver()
    {
        if (theDistance < 2)
        {
            if (Input.GetButtonDown("open"))
            {
                TakeNineMil();
                pickText.text = "";
                gamecontroller.ins.pickupGun(realGun);
                return;
            }
            pickText.text = "Take"+gunName;
        }
    }
    private void OnMouseExit()
    {
        pickText.text = "";
    }*/
}
