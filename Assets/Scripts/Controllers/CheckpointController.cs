using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerRespawnController>().lastPosition = transform.position;
        }
    }
}
