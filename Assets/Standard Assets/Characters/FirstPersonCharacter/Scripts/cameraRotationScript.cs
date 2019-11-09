using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotationScript : TouchLogic {

    public float cameraSpeed=10.0f;
    float pitch = 0.0f;
    float yaw = 0.0f;
    void OnTouchMovedAnyware(){
        pitch += Input.GetTouch(0).deltaPosition.y * cameraSpeed * Time.deltaTime;
        yaw += Input.GetTouch(0).deltaPosition.x * cameraSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
