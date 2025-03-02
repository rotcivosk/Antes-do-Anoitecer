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


    public void Apply(CharacterHandler player, PlaceResources place, EventManager eventManager)
    {
        float totalProbability = 0;
        foreach (var possibility in possibilities)
        {
            totalProbability += possibility.probability;
        }
           // Gerar um valor aleatório entre 0 e totalProbability
        float randomValue = Random.value * totalProbability;
        float cumulative = 0f;


        foreach (var possibility in possibilities)
        {
            cumulative += possibility.probability;
            if (randomValue <= cumulative)
            {
                effects = possibility.effects;
                resultDescription = possibility.possibilityResultText;
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