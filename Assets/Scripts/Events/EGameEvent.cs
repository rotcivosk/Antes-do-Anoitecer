using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Game/Event")]
public class GameEvent : ScriptableObject
{
    public string eventName; // Nome do evento (ex: "Acidente na Estrada")
    [TextArea] public string eventDescription; // Texto que aparece na UI do evento
    public GameAction[] possibleActions; // Até 3 ações para escolher
    public Sprite eventImage; // Imagem do evento

}