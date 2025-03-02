using UnityEngine;
public class CharacterHandler : MonoBehaviour
{
    // Itens do Personagem
    [SerializeField] public PlayerImages playerImages;
    [SerializeField] public PlayerStatus playerStatus;
    [SerializeField] public CharacterResources characterResources;

    [SerializeField] GameObject miniPlayer;
    public int playerIndex {set; get;}

    [SerializeField] private PlaceResources startingPlace;
    private PlaceResources _currentPlace;

    public PlaceResources currentPlace
    {
        get => _currentPlace;
        set
        {
            if (_currentPlace == value) return; // Evita reatribuição desnecessária
            _currentPlace = value;
            SetMiniPlayerLocation();
        }
    }
    void Awake()
    {
        if (playerImages == null)
            playerImages = new PlayerImages();
    }

    public bool isSelected = false;
    public bool isCurrentlyInAction = false;
    public ActionType actionType { get; set; } = ActionType.None;
    public float currentActionStartTime;
    public float currentActionFinishTime;
    [SerializeField] private string _playerName;
    public string playerName {get =>_playerName;set => _playerName = value;}
    public PlaceResources placeToGo {get;set;}
    public float currentActionPercentage;
    void Start()
    {
        
        _currentPlace = startingPlace;
        placeToGo = startingPlace;
        SetMiniPlayerLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        playerStatus.isDead = true;
    }
   

    public Sprite getPlaceSprite(){
        return currentPlace.GetPlaceSprite();
    }
    public void SetMiniPlayerLocation(){
         miniPlayer.transform.position = currentPlace.playerPositions[playerIndex];
    }
    public string getCurrentAction() {

        if (!isCurrentlyInAction) {
            return "Parado em " + currentPlace.placeName;
        }
        return actionType switch {
            ActionType.None => $"Parado em {currentPlace.placeName}",
            ActionType.ImproveDefense => $"Reforçando a defesa em {currentPlace.placeName}",
            ActionType.Looting => $"Saqueando em {currentPlace.placeName}",
            ActionType.ClearDanger => $"Diminuir Perigo em {currentPlace.placeName}",
            ActionType.Search => $"Observando {currentPlace.placeName}",
            ActionType.Relax => $"Descansando em {currentPlace.placeName}",
            ActionType.Move => $"Movendo para {placeToGo.placeName}",
            _ => "Nada"
        };
    }
}


[System.Serializable]
public class PlayerImages
{
    public Sprite miniPlayerSprite;
    public Sprite playerSprite;
    public Sprite playerHungrySprite;
    public Sprite playerDeadSprite;
    public Sprite playerCrazySprite;
}

[System.Serializable]
public class PlayerStatus
{
    public bool isHungry = false;
    public bool isDead = false;
    public bool isCrazy = false;
    public bool isSick = false;
    public bool isTired = false;

}