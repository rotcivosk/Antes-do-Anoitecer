using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class EventUI : MonoBehaviour
{
    public GameEvent currentGameEvent; // Painel de eventos na UI
    [SerializeField] TMP_Text eventName; 
    [SerializeField] TMP_Text eventDescription;
    [SerializeField] TMP_Text eventOption1;
    [SerializeField] TMP_Text eventOption2;
    [SerializeField] TMP_Text eventOption3;
    [SerializeField] TMP_Text eventResult;
    [SerializeField] GameObject okButton;
    [SerializeField] Image eventImage;
    [SerializeField] Image playerImage;
    void Start()
    {
        
    }
        
    public void updateEventUI(GameEvent currentGameEvent){
        eventName.text = currentGameEvent.eventName;
        eventDescription.text = currentGameEvent.eventDescription;
        if (currentGameEvent.possibleActions[0] == null) {
            eventOption1.text = "";
        } else {
            eventOption1.text = currentGameEvent.possibleActions[0].actionName;
        }
        if (currentGameEvent.possibleActions[1] == null) {
            eventOption2.text = "";
        } else {
            eventOption2.text = currentGameEvent.possibleActions[1].actionName;
        }
        if (currentGameEvent.possibleActions[2] == null) {
            eventOption3.text = "";
        } else {
            eventOption3.text = currentGameEvent.possibleActions[2].actionName;
        }
        eventResult.text = "";
        okButton.SetActive(false);

    }

    public void updateImages(GameEvent currentGameEvent, PlayerHandler player){
        eventImage.sprite = currentGameEvent.eventImage;
        playerImage.sprite = player.miniPlayerSprite;

    }

    public void updateResultUI(GameEvent gameEvent, GameAction choosenAction){
        eventName.text = gameEvent.eventName;
        eventDescription.text = "";
        eventOption1.text = "";
        eventOption2.text = "";
        eventOption3.text = "";
        eventResult.text = choosenAction.resultDescription;
        okButton.SetActive(true);
    }    
}