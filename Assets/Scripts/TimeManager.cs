using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastTime)
        {
            Debug.Log(lastTime);
            lastTime++;
        }

    }
}
