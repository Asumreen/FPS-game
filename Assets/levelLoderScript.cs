using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelLoderScript : MonoBehaviour {
public List<GameObject> Levels;
	List<Vector3> pos;
	// Use this for initialization
	void Start () {
		pos=new List<Vector3>();
		pos.Add(new Vector3(1.608582f,2.6f,-46.38814f));
		pos.Add(new Vector3(-27.446f,5.045f,-8.7f));
		pos.Add(new Vector3(-45.11f,5.078f,45.728f));
		pos.Add(new Vector3(-30.189f,7.78f,30.712f));
	}
	public void lodeLevel(int number){
		GameObject currlevel=Instantiate(Levels[number],pos[number],Quaternion.identity);
		if(number==0){
			currlevel.gameObject.transform.Rotate(new Vector3(-5,0,0));
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
}
