using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {
    public int points=25;
    // Use this for initialization


    // Update is called once per frame
    public void DeductPoints(int damgeAmount)
    {
        gamecontroller.ins.addToScour(points);
    }
}
