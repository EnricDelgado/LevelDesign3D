using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnController : MonoBehaviour
{
    [HideInInspector] public Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        #region Debug
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Respawn();
        }
        #endregion
    }

    public void Respawn()
    {
        transform.position = lastPosition;
    }
}
