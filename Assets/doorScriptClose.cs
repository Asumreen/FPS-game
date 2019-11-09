using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScriptClose : MonoBehaviour {
public static doorScriptClose ins;

public void doorClosed(){
string index= gameObject.transform.parent.name;
Debug.Log(index.Length);
}
public void play(){
	gameObject.GetComponent<Animation>().Play();
}
}
