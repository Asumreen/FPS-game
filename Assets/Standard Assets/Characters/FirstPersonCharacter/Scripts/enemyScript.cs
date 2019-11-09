using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int enemyHealth = 10;
    public void DeductPoints(int damgeAmount)
    {
        enemyHealth -= damgeAmount;
    }
    private void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
