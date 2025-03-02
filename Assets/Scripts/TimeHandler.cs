using UnityEngine;
using System;
public class TimeHandler : MonoBehaviour
{
    public static TimeHandler Instance;
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
    [SerializeField] public float ultraFastSpeed;
    [SerializeField] NightHandler nightHandler;
    public bool isNight = false;
    private void Awake()    {
        Instance = this;
    }

    void Start()    {
        timeController = 0;
    }
    // Update is called once per frame
    void Update()    {
        CheckIfTimePassed();  
        
        CheckforClicks();
        
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
        CheckForNight();
        CheckForSkipNight();
    }

    void CheckForNight()    {
        if (!isNight && timeHour >= 18)
        {
            isNight = true;
            nightHandler.StartNight();
        }
    }
    void CheckForSkipNight()    {
        if (timeHour >= 19)        {
            ultraFastTime();
        }
        if (timeHour >= 6 && timeHour < 9 && isNight)
        {
            resumeTime();
            isNight = false;
            nightHandler.EndNight();
            dayValue++;
        }
    }
    private void CheckforClicks(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            pauseTime();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            resumeTime();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            fastTime();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            ultraFastTime();
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
    public void ultraFastTime(){
        delayUpdate = ultraFastSpeed;
        Debug.Log ("Time Ultra Fast");
    }

    public void skipNight(){
        if (!isNight) return;
        ultraFastTime();
        while (timeHour < 6)        {
            UpdateEverySecond();
        }
        pauseTime();
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