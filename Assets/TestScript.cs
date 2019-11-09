using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
	public List<GameObject> Levels;
	List<Vector3> pos;
	// Use this for initialization
	void Start () {
		pos=new List<Vector3>();
		pos.Add(new Vector3(1.608582f,2.6f,-46.38814f));
		pos.Add(new Vector3(-27.446f,5.045f,-8.7f));
		pos.Add(new Vector3(-45.11f,5.078f,45.728f));
		pos.Add(new Vector3(-30.189f,7.78f,30.712f));

		foreach(GameObject level in Levels){
			int index=Levels.IndexOf(level);
			Instantiate(level,pos[index],Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
