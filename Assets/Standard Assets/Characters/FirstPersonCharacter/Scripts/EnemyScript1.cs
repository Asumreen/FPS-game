using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript1 : MonoBehaviour {
    public GameObject thePlayer;
    public GameObject Enemy;
    float EnemyHealth = 20f;
    float TargetDistance;
    float AllowRange = 10f;
    float EnemySpeed;
    bool AttackTriger=false;
    RaycastHit shot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(thePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            if (shot.collider.gameObject.tag == "Player")
            {
                TargetDistance = shot.distance;
                if (TargetDistance < AllowRange)
                {
                    EnemySpeed = 0.02f;
                    if (!AttackTriger)
                    {
                        Enemy.GetComponent<Animation>().Play("Walking");
                        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, EnemySpeed);
                    }
                }
                else
                {
                    Enemy.GetComponent<Animation>().Play("Idle");
                }
            }
        }

        if(AttackTriger){
            if(!gamecontroller.ins.GetisAttacking()){
                StartCoroutine(gamecontroller.ins.playerDamged());
            }
            EnemySpeed = 0;
            Enemy.GetComponent<Animation>().Play("Attacking");    
        }
        if(EnemyHealth<=0){
            gamecontroller.ins.addToScour(200);
            Destroy(gameObject);
        }

	}
    public void DeductPoints(int damgeAmount)
    {
        EnemyHealth -= damgeAmount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            AttackTriger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player"){
            AttackTriger = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
    
        EnemySpeed = 0;
    }
}
