using UnityEngine;
public interface IActionEffect
{
    void Apply(PlayerHandler player, PlaceResources place);
}

public class EventManager : MonoBehaviour
{
    public GameObject eventPanel; // Painel de eventos na UI
    public GameEvent[] SearchEvents; // Lista de eventos de busca
    public GameEvent[] LootEvents; // Lista de eventos de saque
    public GameEvent[] DefenseEvents; // Lista de eventos de combate
    public GameEvent[] NightEvents; // Lista de eventos de viagem
    public GameEvent[] SpecialEvents; // Lista de eventos especiais
    public GameEvent[] RelaxEvents; // Lista de eventos de relaxamento
    private PlayerHandler currentPlayer;
    private PlaceResources currentPlace;
    [SerializeField] GameEvent currentEvent; // O evento atual
    [SerializeField] EventUI eventUI; // Painel de eventos na UI
   // private GameEvent selectedEvent; // O evento selecionado
    private GameAction selectedAction; // A ação selecionada
    [SerializeField] private TimeHandler timeHandler; // O controlador de tempo
    public bool isEventActive = false; // Se um evento está ativo
    void Start()
    {
        
    }


    public void TriggerEvent(string eventType, PlayerHandler player, PlaceResources place)
    {
        // Starting event
        isEventActive = true;
        eventPanel.SetActive(true);
        currentPlayer = player;
        currentPlace = place;
        timeHandler.pauseTime();
        GameEvent selectedEvent = GetRandomEvent(eventType);
        currentEvent = selectedEvent;
        eventUI.updateImages(currentEvent, currentPlayer);
        // Selecionando um evento aleatório

        eventUI.updateEventUI(currentEvent);

    }

    public void SelectAction(int actionIndex)
    {
        Debug.Log("Current event: " + currentEvent.eventName);
        selectedAction = currentEvent.possibleActions[actionIndex];
        Debug.Log("Action selected: " + selectedAction.actionName);
        selectedAction.Apply(currentPlayer, currentPlace, this);
        eventUI.updateResultUI(currentEvent,selectedAction);
    }

    // Parte de seleção de eventos

    private GameEvent GetRandomEvent(string eventType) // Search, Loot, Defense, Night, Special, Relax
    {
        switch(eventType)
        {
            case "Search":
                return GetRandomEventFromList(SearchEvents);
            case "Loot":
                return GetRandomEventFromList(LootEvents);
            case "Defense":
                return GetRandomEventFromList(DefenseEvents);
            case "Night":
                return GetRandomEventFromList(NightEvents);
            case "Special":
                return GetRandomEventFromList(SpecialEvents);
            case "Relax":
                return GetRandomEventFromList(RelaxEvents);
            default:
                return null;
        }
    }
    private GameEvent GetRandomEventFromList(GameEvent[] eventList)
    {
        if (eventList.Length > 0)
        {
            return eventList[Random.Range(0, eventList.Length)];
        }
        return null;
    }
    
    public void FinishEvent()
    {
        eventPanel.SetActive(false);
        timeHandler.resumeTime();
        isEventActive = false;
    }
    
}