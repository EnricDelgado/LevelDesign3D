using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewController : MonoBehaviour
{
    StaticEnemyController parentEnemy;

    private void Start()
    {
        parentEnemy = transform.parent.gameObject.GetComponent<StaticEnemyController>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            parentEnemy.playerDetected = true;
        }
    }
}
