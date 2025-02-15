
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerHandler : MonoBehaviour, IPointerClickHandler
{

    private float playerSanity = 100f;
    public bool isDead = false;
    private PlaceResources placeResources;
    public bool isSelected = false;
    public bool isCurrentlyInAction = false;
    public int actionType = 0; // 0 = Nada, 1 = Aumentar Defesa, 2 = Diminuir Looting, 3 = Diminuir Perigo
    public float currentActionStartTime;
    public float currentActionFinishTime;
    public string playerName;
    [SerializeField] public Sprite miniPlayerSprite;
    [SerializeField] PlayerUI playerUI;
    [SerializeField] PlaceResources startingPlace;
    private PlaceResources placeToGo;
    public float currentActionPercentage;
    void Start()
    {
        placeResources = startingPlace;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    // Código para a seleção de Personagens
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = false;
        playerUI.setPlayerHandler(this);
    }


    // Pegar a porcentagem da ação atual





    // Getters e Setters pq deus quis
    public void addSanity(float value){
        playerSanity = math.clamp(playerSanity + value, 0, 100);
    }
    public void removeSanity(float value){
        playerSanity = math.clamp(playerSanity - value, 0, 100);
        if (playerSanity == 0){
            isDead = true;
        }

    }
    public float getSanity(){
        return playerSanity;
    }
    public void setPlaceResources(PlaceResources placeResources){
        this.placeResources = placeResources;
    }
    public PlaceResources getCurrentPlace(){
        return placeResources;
    }
    public string getPlayerName(){
        return playerName;
    }
    public Sprite getPlayerSprite(){
        return miniPlayerSprite;
    }
    public string getPlaceName(){
        return placeResources.getPlaceName();
    }
    public Sprite getPlaceSprite(){
        return placeResources.GetPlaceSprite();
    }
    public void setPlaceToGo(PlaceResources place){
        placeToGo = place;
    }
    public PlaceResources getPlaceToGo(){
        return placeToGo;
    }
}
