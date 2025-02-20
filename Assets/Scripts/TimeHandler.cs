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

    public int timeDay = 0; 
    public string timeAsString;
    public int dayValue = 1;
    [SerializeField] UIHandler uiHandler;
    // Start is called before the first frame update


    [SerializeField] public float normalSpeed;
    [SerializeField] public float fastSpeed;
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
        uiHandler.UpdatedEverySecond();
        timeHour = timeManager.GetJustDay(Mathf.FloorToInt(timeController));
        if(timeHour == 10){
            timeDay++;
            dayValue++;
        }
    }

    public void CheckforClicks(){
        // se clicar no número 1 do teclado, pausa o tempo
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            pauseTime();
        }
        // se clicar no número 2 do teclado, resumo o tempo
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            resumeTime();
        }
        // se clicar no número 3 do teclado, acelera o tempo
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            fastTime();
        }
    }

    // Funções de controle de tempo
    public void pauseTime(){
        delayUpdate = 0;
        Debug.Log ("Time Paused");
    }
    public void resumeTime(){
        delayUpdate = normalSpeed;
        Debug.Log ("Time Resumed");
    }
    public void fastTime(){
        delayUpdate = fastSpeed;
        Debug.Log ("Time Fast");
    }


    public void skipNight(){
        
        timeController += 720;
    }

}
public class TimeManager
{
    private DateTime currentTime;

    public TimeManager(int startHour = 12, int startMinute = 0) {
        currentTime = new DateTime(2024, 1, 1, startHour, startMinute, 0); // Data inicial arbitrária
    }
    public string GetTime(int counter) {
        DateTime newTime = currentTime.AddMinutes(counter);
        return newTime.ToString("HH:mm");
    }
    public string GetTimeWithDay(int counter) {
        DateTime newTime = currentTime.AddMinutes(counter);
        return newTime.ToString("dd/MM HH:mm");
    }
    public int GetJustDay(int counter) {
        DateTime newTime = currentTime.AddMinutes(counter);
        return newTime.Hour;
    }

}