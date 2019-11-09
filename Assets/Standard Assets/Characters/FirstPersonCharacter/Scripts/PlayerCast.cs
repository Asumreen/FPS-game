using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCast : MonoBehaviour {
    public static float DistanceFromTarget;
    public static GameObject target;
    float ToTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            target = hit.collider.gameObject;
            ToTarget = hit.distance;
            DistanceFromTarget = ToTarget;
        }
	}
}
