
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
public class PlayerHandler : MonoBehaviour, IPointerClickHandler
{


    // Itens do Personagem
    [SerializeField] int food = 3;
    [SerializeField] int maxFood = 10;
    [SerializeField] bool isHungry = false;
    [SerializeField] UIHandler UIHandler;   
    [SerializeField] PlayerItens playerItens;




    private float playerSanity = 100f;
    public bool isDead = false;
    private PlaceResources currentPlace;
    public bool isSelected = false;
    public bool isCurrentlyInAction = false;
    public int actionType = 5; // 0 = Nada, 1 = Aumentar Defesa, 2 = Diminuir Looting, 3 = Diminuir Perigo, 4 = Observar Local, 5 = Descansar
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
        currentPlace = startingPlace;
        placeToGo = startingPlace;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // Código para a seleção de Personagens
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = false;
        UIHandler.setPlayerHandler(this);
    }

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
    public int getFoodValue(){
        return food;
    }

    public void updateFood(int changedValue){
        if (food > 0 || food<maxFood){    
            food = food + changedValue;
        }
    }
    public void setPlaceResources(PlaceResources placeResources){
        this.currentPlace = placeResources;
    }
    public PlaceResources getCurrentPlace(){
        return currentPlace;
    }
    public string getPlayerName(){
        return playerName;
    }
    public Sprite getPlayerSprite(){
        return miniPlayerSprite;
    }
    public string getPlaceName(){
        return currentPlace.getPlaceName();
    }
    public Sprite getPlaceSprite(){
        return currentPlace.GetPlaceSprite();
    }
    public void setPlaceToGo(PlaceResources place){
        placeToGo = place;
    }
    public PlaceResources getPlaceToGo(){
        return placeToGo;
    }
    public void setActionType(int action){
        actionType = action;
    }
    public int getActionType(){
        return actionType;
    }
    public string getCurrentAction() {
        Debug.Log ("Cheguei no getCurrentAction");
        Debug.Log ("ActionType: " + actionType);
        Debug.Log ("isCurrentlyInAction: " + isCurrentlyInAction);
        Debug.Log ("currentPlace: " + currentPlace.getPlaceName());


        if (!isCurrentlyInAction) {
            return "Parado em " + currentPlace.getPlaceName();
        }
        switch (actionType){
            case 0:
                return "Parado em " + currentPlace.getPlaceName();
            case 1:
                return "Reforçando a defesa em " + currentPlace.getPlaceName();
            case 2:
                return "Saqueando em " + currentPlace.getPlaceName();
            case 3:
                return "Diminuir Perigo" + currentPlace.getPlaceName();
            case 4:
                return "Observando " + currentPlace.getPlaceName();
            case 5:
                Debug.Log ("Identifiquei que é caso 5");
                return "Descansando em " + currentPlace.getPlaceName();
            case 6:
                return "Movendo para " + placeToGo.getPlaceName();
            default:
                return "Nada";
        }
    }



    // Setters dos itens
    
    public void setCar(bool value){
        playerItens.hasCar = value;
    }
    public void setBeer(bool value){
        playerItens.hasBeer = value;
    }
    public void setMedkit(bool value){
        playerItens.hasMedkit = value;
    }
    public void setFlashlight(bool value){
        playerItens.hasFlashlight = value;
    }
    public void setBinoculars(bool value){
        playerItens.hasBinoculars = value;
    }
    public bool getCar(){
        return playerItens.hasCar;
    }
    public bool getBeer(){
        return playerItens.hasBeer;
    }
    public bool getMedkit(){
        return playerItens.hasMedkit;
    }
    public bool getFlashlight(){
        return playerItens.hasFlashlight;
    }
    public bool getBinoculars(){
        return playerItens.hasBinoculars;
    }
    

}

[System.Serializable]
public class PlayerItens{
    public bool hasCar = false;
    public bool hasBeer = false;
    public bool hasMedkit = false;
    public bool hasFlashlight = false;
    public bool hasBinoculars = false;
}