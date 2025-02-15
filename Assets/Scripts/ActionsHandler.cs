using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class ActionsHandler : MonoBehaviour
{
    public TimeHandler timeHandler;
    [SerializeField] PlayerHandler[] players; // 0 = Player1, 1 = Player2, 2 = Player3, 3 = Player4

    [SerializeField] int improveDefenseDuration;
    [SerializeField] int startLootingDuration;
    [SerializeField] int clearDangerDuration;

    void Start()
    {

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
        player.actionType = 0; //Ação 0 é de se locomover
        StartAction(player, CalculateDurationMovement(player.getCurrentPlace(), place));
        player.setPlaceToGo(place);
    }

    // Calcular o tempo de duração da distância entre os lugares
    private int CalculateDurationMovement(PlaceResources place1, PlaceResources place2){
        return 20;
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
        StartAction(player, startLootingDuration);
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
        Debug.Log("Ação de " + player.getPlayerName() + " terminado");

        finishAction(player); 
    }
    private void finishAction(PlayerHandler player){
        PlaceResources place = player.getCurrentPlace();
        if (player.actionType == 0) {
            Debug.Log("Movendo " + player.getPlayerName() + " para " + place.getPlaceName());
            player.setPlaceResources(player.getPlaceToGo());
        }
        if (player.actionType == 1) {
            Debug.Log("Aumentando a defesa de " + place.getPlaceName() + " em 10");
            place.addDefenseValue(10);
        }
        if (player.actionType ==  2) {
            Debug.Log("Diminuindo o looting de " + place.getPlaceName() + " em 10");
            place.addLootingValue(-10);
        }
        if (player.actionType ==  3) {
            Debug.Log("Diminuindo o perigo de " + place.getPlaceName() + " em 10");
            place.addDangerValue(-10);
        }
        player.isCurrentlyInAction = false;
        player.actionType = 0;
    }

}