using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class GunFire : MonoBehaviour {
    AudioSource gunSound;
    public GameObject flash;

    gamecontroller temp;
   
    bool reloding=false;
    // Use this for initialization
    private void Awake()
    {
      
    }
    void Start () {
        gunSound = GetComponent<AudioSource>();
        temp = gamecontroller.ins;
	}
	
	// Update is called once per frame
	void Update () {
        if(CrossPlatformInputManager.GetButtonDown("Fire1")&&gamecontroller.ins.canShoot()){
            flash.gameObject.SetActive(true);
            StartCoroutine(endflash());
            //gunSound.Play();
            gunSound.PlayOneShot(gunSound.clip);
            GetComponent<Animation>().Play("GunShotM9");
            gamecontroller.ins.shoot9m();
        }
        if (CrossPlatformInputManager.GetButtonDown("Relode")&&temp.getOnGun9m()<12){
            StartCoroutine(temp.relode9m());
            }
        }
	

    IEnumerator endflash(){
        yield return new WaitForSeconds(0.1f);
        flash.gameObject.SetActive(false);
    }
   
  
 
  
 
}
