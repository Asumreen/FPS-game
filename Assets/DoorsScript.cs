using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorsScript : MonoBehaviour {
	Animator myainmator;
	public bool levelDoor;
	// Use this for initialization
	void Start () {
		myainmator=gameObject.GetComponent<Animator>();
	}

	IEnumerator close(){
		yield return new WaitForSeconds(2);
		myainmator.SetBool("close",true);
		yield return new WaitForSeconds(1);
		myainmator.SetBool("close",false);
		if(levelDoor){
			myainmator.enabled=false;
			string index=gameObject.transform.parent.name;
		//	gamecontroller.ins.levelDone(int .Parse(index[index.Length-1].ToString()));
		}

	}
	IEnumerator open(){
			myainmator.SetBool("open",true);
			yield return new WaitForSeconds(1);
			myainmator.SetBool("open",false);
			if(!levelDoor)
			StartCoroutine("close");
	}
}