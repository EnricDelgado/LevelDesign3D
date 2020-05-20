using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealController : MonoBehaviour
{
    Collider StealArea;
    bool isCrouching = false;
    bool nearEnemy = false;

    GameObject KeyEnemy;
    GameObject[] enemies;
    Color enemyColor;
    bool changeColor;

    // Start is called before the first frame update
    void Start()
    {
        StealArea = GetComponent<SphereCollider>();

        enemies = GameObject.FindGameObjectsWithTag("Key");
        enemyColor = enemies[0].GetComponent<Renderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        isCrouching = GetComponent<PlayerMovement>().isCrouching;

        // Debug.Log("Is crouching: " + isCrouching);
        changeColor = false;

        if(nearEnemy)
        {
            if(isCrouching)
            {
                Debug.Log("Steal now");
                changeColor = true;
            }
            else
            {
                Debug.Log("Player detected");
                changeColor = false;
            }
        }
        
        if(changeColor)
        {
            KeyEnemy.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            
        }
        else
        {
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<Renderer>().material.SetColor("_Color", enemyColor);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name + " entering trigger");
        if(other.tag == "Key")
        {
            Debug.Log("Near enemy");
            nearEnemy = true;
            KeyEnemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Key")
        {
            nearEnemy = false;
        }
    }
}
