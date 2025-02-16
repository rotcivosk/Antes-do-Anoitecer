using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class EventsUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text eventText;
    [SerializeField] TMP_Text descriptionText; 
    [SerializeField] TMP_Text option1Text; 
    [SerializeField] TMP_Text option2Text; 
    [SerializeField] TMP_Text option3Text; 

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateTextFields(EventsHandler events){
        eventText.text = events.eventsName;
        descriptionText.text = events.eventsDescription;
        updateOptionText(option1Text, events.actionDescription1);
        updateOptionText(option2Text, events.actionDescription2);
        updateOptionText(option3Text, events.actionDescription3);


    }

    private void updateOptionText(TMP_Text UIText, string NewText){
        if (NewText ==""){
            UIText.text = "";
        }else{
            UIText.text = NewText;
        }
    }
}
