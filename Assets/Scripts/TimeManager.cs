using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime;
    private float timer;

    [SerializeField]
    private Transform[] transformArray;

    const float moveWait = 2.0f;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        ResetTime();
        cam = Camera.main;
        cam.orthographic = true;
        cam.orthographicSize = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= lastTime)
        {
            Debug.Log(lastTime);
            lastTime++;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }

        #region PauseSpace
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
        #endregion

    }

    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;
    }
}
