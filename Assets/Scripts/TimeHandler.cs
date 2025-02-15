using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] float nextUpdate = 1;
    private float delayUpdate = 1;
    public float timeController;
    TimeManager timeManager = new TimeManager(06, 00); // Começa às 12:57
    public int timeHour = 0;
    public int timeMinute = 0;
    public int timeDay = 0; 
    public string timeAsString;
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
        timeAsString = timeManager.GetTime(Mathf.FloorToInt(timeController));
    }



    // Transformar o valor de segundos em um horário

















    
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
public class TimeManager
{
    private DateTime currentTime;

    public TimeManager(int startHour = 12, int startMinute = 0)
    {
        currentTime = new DateTime(2024, 1, 1, startHour, startMinute, 0); // Data inicial arbitrária
    }

    public string GetTime(int counter)
    {
        DateTime newTime = currentTime.AddMinutes(counter);
        return newTime.ToString("HH:mm");
    }
    public string GetTimeWithDay(int counter)
    {
        DateTime newTime = currentTime.AddMinutes(counter);
        return newTime.ToString("dd/MM HH:mm");
    }
}