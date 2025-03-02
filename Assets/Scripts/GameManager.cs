using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PlaceResources[] places;
    [SerializeField] private CharacterHandler[] players;

    public PlaceResources[] Places => places; // Função lambda, é o mesmo que não ter um get e set
    public CharacterHandler[] Players => players;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public CharacterHandler GetSelectedPlayer()
    {
        foreach (CharacterHandler player in players)
        {
            if (player.isSelected) return player;
        }
        return null;
    }
    public PlaceResources GetSelectedPlace()
    {
        foreach (PlaceResources place in places)
        {
            if (place.isSelected) return place;
        }
        return null;
    }
    public PlaceResources GetMouseOverPlace()
    {
        foreach (PlaceResources place in places)
        {
            if (place.isMouseOver) return place;
        }
        return null;
    }
}

