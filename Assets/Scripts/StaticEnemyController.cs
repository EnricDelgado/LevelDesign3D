using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyController : MonoBehaviour
{
    public bool playerDetected = false;
    public float rotationSpeed = 2f;
    public float rotationAngle = 45;
    public float rotationCooldown = 1;

    bool turnLeft = false, turnRight = true;

    // Update is called once per frame
    void Update()
    {
        if(!playerDetected)
        {
            if(turnRight == true)
            {
                StartCoroutine(TurnRight(rotationCooldown));

            }
            if(turnLeft == true)
            {
                StartCoroutine(TurnLeft(rotationCooldown));
            }
        }
        else
        {
            rotationSpeed = 0;
            Debug.Log(transform.name + " detected player");
        }
    }

    IEnumerator RotationCooldown(bool rotation, float Cooldown)
    {
        yield return new WaitForSeconds(Cooldown);
        rotation = true;
    }

    IEnumerator TurnRight(float Cooldown)
    {
        Debug.Log(transform.name + " turning right");
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + rotationAngle, transform.rotation.z), rotationSpeed * Time.deltaTime);

        yield return new WaitForSeconds(Cooldown);
        turnRight = false;
        turnLeft = true;
    }

    IEnumerator TurnLeft(float Cooldown)
    {
        Debug.Log(transform.name + " turning left");
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y - rotationAngle, transform.rotation.z), rotationSpeed * Time.deltaTime);

        yield return new WaitForSeconds(Cooldown);
        turnLeft = false;
        turnRight = true;
    }
}
