using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealController : MonoBehaviour
{
    bool isCrouching = false;
    public bool nearKeyEnemy = false;

    public GameObject KeyEnemy;
    GameObject[] enemies;
    Color enemyColor;
    bool changeColor;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Key");
        enemyColor = enemies[0].GetComponent<Renderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        isCrouching = GetComponent<PlayerMovement>().isCrouching;

        changeColor = false;

        if(nearKeyEnemy)
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
}
