using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class touchScreen : MonoBehaviour {
    public FixedTouchField FixedTouchField;
    FirstPersonController Rg;
	// Use this for initialization
	void Start () {
        Rg = GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
        Rg.m_MouseLook.LookAxis = FixedTouchField.TouchDist;




    }
}
