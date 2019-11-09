using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CroosAinmat : MonoBehaviour {
    public GameObject upCurs;
    public GameObject DownCurs;
    public GameObject leftCurs;
    public GameObject rightCurs;
    gamecontroller temp;
    // Use this for initialization
    void Start () {
        temp = gamecontroller.ins;
	}
	
	// Update is called once per frame
	void Update () {
        string name = gamecontroller.ins.getActiveGun();
       // Debug.Log(name);
        if (((name=="M9"&& CrossPlatformInputManager.GetButtonDown("Fire1"))||(name=="AK-47"&& CrossPlatformInputManager.GetButton("Fire1")))&& gamecontroller.ins.canShoot())
        {
            upCurs.GetComponent<Animator>().enabled = true;
            DownCurs.GetComponent<Animator>().enabled = true;
            leftCurs.GetComponent<Animator>().enabled = true;
            rightCurs.GetComponent<Animator>().enabled = true;

        }
	}
    public void AinmDisable(){
        upCurs.GetComponent<Animator>().enabled = false;
        DownCurs.GetComponent<Animator>().enabled = false;
        leftCurs.GetComponent<Animator>().enabled = false;
        rightCurs.GetComponent<Animator>().enabled = false;
    }
}
