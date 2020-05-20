using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthSystem : MonoBehaviour
{
    public LayerMask EnemyLayer;
    GameObject KeyEnemy;

    bool isCrouching;
    
    bool nearEnemy;
    bool playerDetected;

    void Update()
    {
        isCrouching = GetComponent<PlayerMovement>().isCrouching;

        playerDetected = false;

        if(nearEnemy)
        {
            if(isCrouching)
            {
                Debug.Log("Steal now");
                playerDetected = false;
            }
            else
            {
                Debug.Log("Player detected");
                playerDetected = true;
            }
        }
        
        Debug.Log("Player detected: " + playerDetected);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == EnemyLayer)
        {
            Debug.Log("Near enemy");

            nearEnemy = true;

            if(other.tag == "Key")
            {
                this.GetComponent<StealManager>().nearKeyEnemy = false;
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.layer == EnemyLayer)
        {
            nearEnemy = false;

            if(other.tag == "Key")
            {
                this.GetComponent<StealManager>().nearKeyEnemy = false;
            }
        }
    }
}