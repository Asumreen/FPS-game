using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class openDoorScript : MonoBehaviour {
    public Text openText;
    public GameObject door;
    public GameObject gun;
    float theDistance;
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCast.DistanceFromTarget;
        if (PlayerCast.target!=null&&PlayerCast.target.name == this.name)
        {
            if (theDistance < 2)
            {
                openText.text = "Press Button";
                if (!gun.gameObject.activeInHierarchy && CrossPlatformInputManager.GetButtonDown("open"))
                {
                    door.SendMessage("open");
                }
                else if (CrossPlatformInputManager.GetButtonDown("open") && !gamecontroller.ins.isReloding9m())
                {
                    door.SendMessage("open");

                }

            }
            else{
                openText.text = "";
            }
        }
        if(theDistance>2){
            openText.text = "";
        }
    
    }
}
