using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AKScript : MonoBehaviour {
    AudioSource akSound;
    public GameObject flash;
    gamecontroller temp;
    public static bool shooting = false;
	// Use this for initialization
	void Start () {
        akSound = GetComponent<AudioSource>();
        temp = gamecontroller.ins;
	}
	
	// Update is called once per frame
	void Update () {
        if(CrossPlatformInputManager.GetButton("Fire1")&&temp.canShoot()&!shooting){
            flash.gameObject.SetActive(true);
            StartCoroutine(endFlash());
            akSound.PlayOneShot(akSound.clip);
            temp.shootAK();
            shooting=true;
        }
        if(CrossPlatformInputManager.GetButtonDown("Relode") && temp.getOnGunAK()<30){
            StartCoroutine(temp.relodeAK());
        }
	}
    IEnumerator endFlash(){
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }
    public void endShooting(){
        shooting = false;
    }
}
