using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastTime)
        {
            Debug.Log(lastTime);
            lastTime++;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0)
            {
                Debug.Log("Spacebar pressed");
                Time.timeScale = 1;   
            }
            else
            {
                Debug.Log("Spacebar pressed");
                Time.timeScale = 0;
            }
        }

    }
}
