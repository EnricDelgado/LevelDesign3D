using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthSystem : MonoBehaviour
{
    public LayerMask EnemyLayer;
    GameObject KeyEnemy;
    GameObject CurrentEnemy = null;

    bool isCrouching;
    
    bool nearEnemy;
    public bool playerDetected = false;

    void Update()
    {
        isCrouching = GetComponent<PlayerMovement>().isCrouching;

        if(nearEnemy)
        {
            if(isCrouching)
            {
                playerDetected = false;
            }
            else
            {
                playerDetected = true;
            }
        }
        

        if(playerDetected)
        {
            if(CurrentEnemy.GetComponent<StaticEnemyController>() != null)
            {
                CurrentEnemy.GetComponent<StaticEnemyController>().playerDetected = playerDetected;
            }
        }

        #region Debug
        Debug.Log("Player detected: " + playerDetected);
        Debug.Log("Current enemy: " + CurrentEnemy);
        #endregion
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Key" || other.tag == "Enemy") CurrentEnemy = other.gameObject;

        if(other.tag == "Key")
        {
            GetComponent<StealManager>().KeyEnemy = other.gameObject;
            GetComponent<StealManager>().nearKeyEnemy = true;
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("Near enemy");
            nearEnemy = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Key" || other.tag == "Enemy") CurrentEnemy = null;

        if(other.tag == "Key")
        {
            GetComponent<StealManager>().KeyEnemy = other.gameObject;
            GetComponent<StealManager>().nearKeyEnemy = false;
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("Far enemy");
            nearEnemy = false;
        }
    }
}