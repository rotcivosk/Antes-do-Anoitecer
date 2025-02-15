using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] float nextUpdate = 1;
    private float delayUpdate = 1;
    public float timeController;
    /// Start is called before the first frame update

    void Start()
    {
        timeController = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimePassed();  
    }

    void CheckIfTimePassed(){
        if(delayUpdate==0) return;

    	if(Time.time >= nextUpdate){
    		nextUpdate = Time.time + delayUpdate;
    		UpdateEverySecond();
    	}
    }

    void UpdateEverySecond(){
    	timeController++;
    }
    
    public void pauseTime(){
        delayUpdate = 0;
        Debug.Log ("Time Paused");
    }
    public void resumeTime(){
        delayUpdate = 1;
        Debug.Log ("Time Resumed");
    }
    public void fastTime(){
        delayUpdate = 0.3f;
        Debug.Log ("Time Fast");
    }

}
