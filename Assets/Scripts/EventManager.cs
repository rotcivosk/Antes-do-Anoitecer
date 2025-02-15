using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] EventsHandler[] searchingEvents;
    [SerializeField] EventsUI eventsUI;
    void Start()
    {
        SelectRandomSearchingEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectRandomSearchingEvent()
    {
        // escolhe um número aleatório
        int randomIndex = Random.Range(0, searchingEvents.Length);

        
        EventsHandler selectedEvent = searchingEvents[randomIndex];

        SendEventToUI(selectedEvent);
    }
    private void SendEventToUI(EventsHandler eventData)
    {
        if (eventsUI == null) return;
        
        eventsUI.updateTextFields(eventData);
    }

}
