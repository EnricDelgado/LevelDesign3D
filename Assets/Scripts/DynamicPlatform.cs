using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlatform : MonoBehaviour
{

    public bool startTime;
    public float timer;
    public GameObject platform;
    public bool fallen;

    // Start is called before the first frame update
    void Start()
    {
        startTime = false;
        timer = 4f;
        fallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime == true)
        {
            timer -= 0.02f;
            if(timer <= 0)
            {
                platform.gameObject.SetActive(false);
                startTime = false;
                fallen = true;
                timer = 0;
            }
        }

        if (fallen == true)
        {
            timer += 0.02f;
            if (timer >= 4)
            {
                platform.gameObject.SetActive(true);
                timer = 5;
                fallen = false;
            }
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            startTime = true;
        }
    }
}
