using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyController : MonoBehaviour
{
    public bool playerDetected = false;
    public float rotationSpeed = 2f;
    public float rotationAngle = 45;
    public float rotationCooldown = 4;

    bool turnLeft = false, turnRight = true;

    // Update is called once per frame
    void Update()
    {
        while(!playerDetected)
        {
            if(turnRight == true)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + rotationAngle, transform.rotation.z), rotationSpeed);
                turnRight = false;
                StartCoroutine(RotationCooldown(turnLeft, rotationCooldown));
            }
            if(turnLeft == true)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y - rotationAngle, transform.rotation.z), rotationSpeed);
                turnLeft = false;
                StartCoroutine(RotationCooldown(turnRight, rotationCooldown));
            }
        }
        if(playerDetected)
        {
            rotationSpeed = 0;
            Debug.Log("PlayerDetected");
        }
    }

    IEnumerator RotationCooldown(bool rotation, float Cooldown)
    {
        yield return new WaitForSeconds(Cooldown);
        rotation = true;
    }
}
