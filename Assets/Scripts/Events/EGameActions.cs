using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Game Action", menuName = "Game/Action")]
public class GameAction : ScriptableObject
{
    private EventManager eventManager;
    public string actionName; // Nome da ação (ex: "Pegar um Carro")
    private List<ScriptableObject> effects;  // Lista de efeitos (Binóculos, Medkit, etc.)
    [SerializeField] List<GameActionPossibility> possibilities;  // Lista de possibilidades de ação
    public string resultDescription; // Descrição do resultado da ação


    public void Apply(PlayerHandler player, PlaceResources place, EventManager eventManager)
    {
        for (int i = 0; i < possibilities.Count; i++)
        {
            if (Random.value < possibilities[i].probability)
            {
                effects = possibilities[i].effects;
                resultDescription = possibilities[i].possibilityResultText;
                break;
            }
        }
        foreach (var effect in effects)
        {
            if (effect is IActionEffect actionEffect)
            {
                actionEffect.Apply(player, place);
                
            }
        }

    }
}
[System.Serializable]
public class GameActionPossibility
{
    public List<ScriptableObject> effects;  // Lista de efeitos (Binóculos, Medkit, etc.)
    public float probability;    
    public string possibilityResultText;
}