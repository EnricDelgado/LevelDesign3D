using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCode : MonoBehaviour
{

    public bool open = false;
    public GameObject door;
    public Vector3 doorInitPos;
    public int fNum;
    public int sNum;
    public int tNum;
    public int qNum;
    public GameObject correctLight;
    public GameObject wrongLight;
    public float timerLight;
    bool lightOn;

    // Start is called before the first frame update
    void Start()
    {
        doorInitPos = door.transform.position;
        fNum = 0;
        sNum = 0;
        tNum = 0;
        qNum = 0;
        timerLight = 0;
        lightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (qNum != 0)
        {
            lightOn = true;
            if (fNum == 6&&sNum==1&&tNum==4&&qNum==8)
            {              
                open = true;
            }
            else
            {           
                fNum = 0;
                sNum = 0;
                tNum = 0;
                qNum = 0;
            }
        }

        if (open)
        {
            if(door.transform.position.z<doorInitPos.z+5f)
            {
                door.transform.position += new Vector3(0, 0, 0.05f);
            }
        }

        if (lightOn)
        {
            if (open)
            {
                if (timerLight > 5)
                {
                    correctLight.SetActive(false);
                    lightOn = false;
                }
                else
                {
                    correctLight.SetActive(true);
                    timerLight += 0.05f;
                }
            }
            else
            {
                if (timerLight > 5)
                {
                    wrongLight.SetActive(false);
                    lightOn = false;
                    timerLight = 0;
                }
                else
                {
                    wrongLight.SetActive(true);
                    timerLight += 0.05f;
                }
            }
        }
    }

    
}
