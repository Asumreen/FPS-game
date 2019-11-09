using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class handGunDamde : MonoBehaviour
{
    public int damgeAmount = 5;
    bool canshoot;
    public float targetDistance, allowedRange = 100;
    public GameObject bulletHole;
    RaycastHit hit;
    GameObject parint;
    GameObject hole;

    // Update is called once per frame
    void Update()
    {
        if (gamecontroller.ins.getActiveGun() == "M9")
        {
            damgeAmount = 5;
            canshoot = gamecontroller.ins.canShoot();
            if (CrossPlatformInputManager.GetButtonDown("Fire1") && canshoot)
            {
                RaycastHit shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
                {
                    targetDistance = shot.distance;
                    if (targetDistance <= allowedRange)
                    {
                        shot.transform.SendMessage("DeductPoints", damgeAmount);
                        parint=shot.collider.gameObject;
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            hole=Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.down, hit.normal));
                            hole.transform.parent = parint.transform;
                        }
                    }

                }
            }
        }
        else
        {
            damgeAmount = 2;
            canshoot = gamecontroller.ins.canShoot();
            if (CrossPlatformInputManager.GetButton("Fire1") && canshoot)
            {
                RaycastHit shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
                {
                    targetDistance = shot.distance;
                    if (targetDistance <= allowedRange)
                    {
                        shot.transform.SendMessage("DeductPoints", damgeAmount);
                        parint=shot.collider.gameObject;
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            hole=Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.down, hit.normal));
                            hole.transform.parent = parint.transform;
                        }
                    }

                }
            }
        }
    }
}
