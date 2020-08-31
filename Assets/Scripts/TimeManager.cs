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

    public GameObject red;
    public GameObject blue;

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

            if(lastTime%2 == 0)
            MoveObjects();

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

    private void MoveObjects()
    {

    Vector3 pos1 = new Vector3(2, 1, 0);
    Vector3 pos2 = new Vector3(2, -1, 0);
    Vector3 pos3 = new Vector3(-2, -1, 0);
    Vector3 pos4 = new Vector3(-2, 1, 0);

        if(red.transform.position == pos1)
            red.transform.position = pos2;
        else if(red.transform.position == pos2)
            red.transform.position = pos3;
        else if(red.transform.position == pos3)
            red.transform.position = pos4; 
        else if(red.transform.position == pos4)
            red.transform.position = pos1;
    
        if(blue.transform.position == pos1)
            blue.transform.position = pos2;
        else if(blue.transform.position == pos2)
            blue.transform.position = pos3;
        else if(blue.transform.position == pos3)
            blue.transform.position = pos4;
        else if(blue.transform.position == pos4)
            blue.transform.position = pos1;
    }
}
