using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    #region fields
    private int lastTime;
    private float timer;

    [SerializeField]
    private Transform[] transformArray;

    const float moveWait = 2.0f;

    public GameObject red;
    public GameObject blue;

    Camera cam;

    const float scaleWait = 4.0f;
    #endregion
  
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

            if(lastTime !=0 && lastTime%2 == 0)
            MoveObjects();

            lastTime++;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            float delay = Random.Range(0.25f, 0.75f);
            StartCoroutine(RotateObjects(delay));
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
        CancelInvoke("ScaleObjects");
        timer = 0;
        lastTime = 0;
        InvokeRepeating("ScaleObjects", scaleWait, scaleWait);
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

    private void ScaleObjects()
    {
        Vector3 scale;

        for(int i = 0; i < 2; i++)
        {
        if(transformArray[i].transform.localScale.x > 1.5)
        {
            scale = (transformArray[i].transform.localScale)/1.2f;
            transformArray[i].transform.localScale = scale;
        }
            
        else
        {
            scale = (transformArray[i].transform.localScale)*1.2f;
            transformArray[i].transform.localScale = scale; 
        }
               
        }
        
    }

    IEnumerator RotateObjects(float delay)
    {
        for(int count = 0; count < 4; count++)
        {
        yield return new WaitForSeconds(delay);
        for(int i = 0; i < 2; i++)
            {
                transformArray[i].transform.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
        
        
    }
}
