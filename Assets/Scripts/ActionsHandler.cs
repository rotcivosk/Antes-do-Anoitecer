using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class ActionsHandler : MonoBehaviour
{
    public TimeHandler timeHandler;
    [SerializeField] UIHandler uiHandler;
    [SerializeField] PlayerHandler[] players; // 0 = Player1, 1 = Player2, 2 = Player3, 3 = Player4

    // Duração das ações
    [SerializeField] int improveDefenseDuration;
    [SerializeField] int startLootingDuration;
    [SerializeField] int clearDangerDuration;
    [SerializeField] int searchPlaceDuration;
    [SerializeField] int relaxDuration;

    [SerializeField] PlaceResources startingPlace;
    // Valores das ações
    [SerializeField] int relaxValue;
    [SerializeField] int dangerValue;
    [SerializeField] int lootingValue;
    [SerializeField] int defenceIncreaseValue;





    void Start()
    {
        setForAllPlayersTheCurrentPlace(startingPlace);
    }
    // Update is called once per frame
    void Update()
    {
        CheckForAllActionsTime();
    }


    // Aqui são as ações de Mover o Personagem. Mover é considerado uma ação, btw
    public void MovePlayer(PlaceResources place, PlayerHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.getPlayerName() + " já está em ação");
            return;}
        if (player.getCurrentPlace() == place) {
            Debug.Log (player.getPlayerName() + " já está no lugar");
            return;}
        
        Debug.Log(player.getPlayerName() + "Movendo de " + player.getPlaceName() + " para " + place.getPlaceName());
        player.actionType = 6; //Ação 6 é de se locomover
        player.setPlaceToGo(place);
        StartAction(player, CalculateDurationMovement(player.getCurrentPlace(), place, player));

    }

    // Calcular o tempo de duração da distância entre os lugares
    private int CalculateDurationMovement(PlaceResources place1, PlaceResources place2, PlayerHandler player){
        int calculatedDuration = 20;
        if (player.getCar()) calculatedDuration = calculatedDuration / 2;
        return calculatedDuration;
    }

    // Aqui são as ações do Jogo em si
    public void ImproveDefense(PlaceResources place, PlayerHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.getPlayerName() + " já está em ação");
            return;}
        if (player.getCurrentPlace() != place) {
            Debug.Log (player.getPlayerName() + " não está no lugar");
            return;}

        Debug.Log(player.getPlayerName() + "Aumentando a defesa de " + place.getPlaceName());
        player.actionType = 1; //Define a ação que o player vai fazer
        StartAction(player, improveDefenseDuration);
    }
    public void StartLooting(PlaceResources place, PlayerHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.getPlayerName() + " já está em ação");
            return;}
        if (player.getCurrentPlace() != place) {
            Debug.Log (player.getPlayerName() + " não está no lugar");
            return;}
        Debug.Log(player.getPlayerName() + "Fazendo looting em " + place.getPlaceName());
        player.actionType = 2; //Define a ação que o player vai fazer
        int calculatedDuration = startLootingDuration;
        if (player.getFlashlight()) calculatedDuration = calculatedDuration / 2;
        StartAction(player, calculatedDuration);
    }
    public void ClearDanger(PlaceResources place, PlayerHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.getPlayerName() + " já está em ação");
            return;}
        if (player.getCurrentPlace() != place) {
            Debug.Log (player.getPlayerName() + " não está no lugar");
            return;}
        Debug.Log(player.getPlayerName() + "Limpando defesa em " + place.getPlaceName());
        player.actionType = 3; //Define a ação que o player vai fazer
        StartAction(player, clearDangerDuration);
    }
    public void ObservePlace(PlaceResources place, PlayerHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.getPlayerName() + " já está em ação");
            return;}
        if (player.getCurrentPlace() != place) {
            Debug.Log (player.getPlayerName() + " não está no lugar");
            return;}
        if (place.getObserves()) {
            Debug.Log (player.getPlayerName() + " já vasculhado");
            return;}
        Debug.Log(player.getPlayerName() + "Vasculhando " + place.getPlaceName());
        player.actionType = 4; 
        //Define a ação que o player vai fazer
        int calculatedDuration = searchPlaceDuration;
        if (player.getBinoculars()) calculatedDuration = calculatedDuration / 2;


        StartAction(player, calculatedDuration);
    }
    public void RelaxInPlace(PlaceResources place, PlayerHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.getPlayerName() + " já está em ação");
            return;}
        if (player.getCurrentPlace() != place) {
            Debug.Log (player.getPlayerName() + " não está no lugar");
            return;}
        if (player.getSanity() == 100) {
            Debug.Log (player.getPlayerName() + " já está relaxado");
            return;}
        if (place.getDangerValue() > 50) {
            Debug.Log (player.getPlayerName() + " não pode relaxar em um lugar perigoso");
            return;}
        Debug.Log(player.getPlayerName() + "Relaxando em " + place.getPlaceName());
        player.actionType = 5; //Define a ação que o player vai fazer
        StartAction(player, relaxDuration);
    }

    // Aqui controla o começo, a duração e o fim das ações, respectivamente
    private void StartAction(PlayerHandler player, int actionDuration){
        player.isCurrentlyInAction = true;

        //Calcula o tempo da ação em segundos(do timecontroler e tals)
        player.currentActionStartTime = timeHandler.timeController;
        player.currentActionFinishTime = timeHandler.timeController + actionDuration;
    }
    public void CheckForAllActionsTime(){
        // checks iniciais se está em ação e se já terminou, e se tem uma ação selecionada
        for(int i = 0; i < players.Length; i++){
            CheckForActionTime(players[i]);            
        }
   }
    private void CheckForActionTime(PlayerHandler player){

        // checks iniciais se está em ação e se já terminou, e se tem uma ação selecionada
        if (!player.isCurrentlyInAction) return;
        player.currentActionPercentage = (timeHandler.timeController - player.currentActionStartTime) / (player.currentActionFinishTime - player.currentActionStartTime);
        if (timeHandler.timeController < player.currentActionFinishTime) return;
        player.isCurrentlyInAction = false;
        Debug.Log("Ação de " + player.getPlayerName() + " terminado");
        finishAction(player); 
    }

    private void finishAction(PlayerHandler player){
        PlaceResources place = player.getCurrentPlace();
        switch (player.getActionType()){
            case 1:
                Debug.Log("Aumentando a defesa de " + place.getPlaceName() + " em 10");
                place.addDefenseValue(defenceIncreaseValue);
                break;
            case 2:
                Debug.Log("Diminuindo o looting de " + place.getPlaceName() + " em 10");
                place.addLootingValue(lootingValue);
                break;
            case 3:
                Debug.Log("Diminuindo o perigo de " + place.getPlaceName() + " em 10");
                place.addDangerValue(dangerValue);
                break;
            case 4:
                Debug.Log("Vasculhando " + place.getPlaceName());
                place.setObserves(true);
                break;
            case 5:
                Debug.Log("Relaxando em " + place.getPlaceName());
                if (player.getBeer()) {
                    player.addSanity(relaxValue * 2);
                } else {
                    player.addSanity(relaxValue);
                }
                break;
            case 6:
                Debug.Log("Movendo " + player.getPlayerName() + " para " + player.getPlaceToGo().getPlaceName());
                player.setPlaceResources(player.getPlaceToGo());
                break;
        }
        if(player.isSelected) uiHandler.updatePlayerPanel(player);
        player.isCurrentlyInAction = false;
        player.actionType = 0;
    }



    public void setForAllPlayersTheCurrentPlace(PlaceResources place){
        for(int i = 0; i < players.Length; i++){
            players[i].setPlaceResources(place);
        }
    }

    
}