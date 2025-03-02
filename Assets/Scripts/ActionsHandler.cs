using UnityEngine;
public class ActionsHandler : MonoBehaviour
{
    [SerializeField] PlaceResources startingPlace;
    [SerializeField] EventManager eventManager;
    void Start()     {
        //setForAllPlayersTheCurrentPlace(startingPlace);
    }
    // Update is called once per frame
    void Update()
    {
        CheckForAllActionsTime();
    }


    // Aqui são as ações de Mover o Personagem. Mover é considerado uma ação, btw
    public void MovePlayer(PlaceResources place, CharacterHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.playerName + " já está em ação");
            return;}
        if (player.currentPlace == place) {
            Debug.Log (player.playerName + " já está no lugar");
            return ;}

        player.actionType = ActionType.Move;
        player.placeToGo = place;
        StartAction(player, CalculateDurationMovement(player.currentPlace, place, player));
    }

    // Calcular o tempo de duração da distância entre os lugares
    private int CalculateDurationMovement(PlaceResources place1, PlaceResources place2, CharacterHandler player){
        int calculatedDuration = 30;
        if (player.characterResources.playerItens.hasCar) calculatedDuration = calculatedDuration / 2;
        return calculatedDuration;
    }

    // Aqui são as ações do Jogo em si
    public void ImproveDefense(PlaceResources place, CharacterHandler player){
        if (!CanPerformAction(place, player)) return;

        player.actionType = ActionType.ImproveDefense;
        StartAction(player, ActionType.ImproveDefense.GetDuration(player));
    }
    public void StartLooting(PlaceResources place, CharacterHandler player){
        if (!CanPerformAction(place, player)) return;

        player.actionType = ActionType.Looting;
        StartAction(player, ActionType.Looting.GetDuration(player));
    }
    public void ClearDanger(PlaceResources place, CharacterHandler player){
        if (!CanPerformAction(place, player)) return;

        player.actionType = ActionType.ClearDanger;
        StartAction(player, ActionType.ClearDanger.GetDuration(player));
    }
    public void ObservePlace(PlaceResources place, CharacterHandler player){
        if (!CanPerformAction(place, player)) return;

        if (place.isVerified) {
            Debug.Log (player.playerName + " já vasculhado");
            return;}
        player.actionType = ActionType.Search;
        StartAction(player, ActionType.Search.GetDuration(player));
    }
    public void RelaxInPlace(PlaceResources place, CharacterHandler player){
        if (!CanPerformAction(place, player)) return;

        if (player.characterResources.playerSanity == 100) {
            Debug.Log (player.playerName + " já está relaxado");
            return;}
        if (place.dangerValue > 50) {
            Debug.Log (player.playerName + " não pode relaxar em um lugar perigoso");
            return;}
        player.actionType = ActionType.Relax;
        StartAction(player, ActionType.Relax.GetDuration(player));
    }

    private bool CanPerformAction(PlaceResources place, CharacterHandler player){
        if (player.isCurrentlyInAction) {
            Debug.Log (player.playerName + " já está em ação");
            return false;}
        if (player.currentPlace != place) {
            Debug.Log (player.playerName + " não está no lugar");
            return false;}
        return true;
    }
    public void SleepThroughtNight(CharacterHandler player){

        Debug.Log(player.playerName + "Dormindo");
        player.actionType = ActionType.Sleep;
        StartAction(player, player.playerIndex * 5);
    }

    // Aqui controla o começo, a duração e o fim das ações, respectivamente
    private void StartAction(CharacterHandler player, int actionDuration){
        player.isCurrentlyInAction = true;
       // int tempDuration = player.actionType.GetDuration(player);
        UIHandler.Instance.ForceUpdate();
        //Calcula o tempo da ação em segundos(do timecontroler e tals)
        player.currentActionStartTime = TimeHandler.Instance.timeController;
        player.currentActionFinishTime = TimeHandler.Instance.timeController + actionDuration;
    }
    public void CheckForAllActionsTime(){
        // checks iniciais se está em ação e se já terminou, e se tem uma ação selecionada
        if (GameManager.Instance.Players == null) {
            Debug.Log("Players Não instanciados");
            return;
        }
        foreach(CharacterHandler player in GameManager.Instance.Players){
            CheckForActionTime(player);
        }
   }
    private void CheckForActionTime(CharacterHandler player){

        // checks iniciais se está em ação e se já terminou, e se tem uma ação selecionada
        if (!player.isCurrentlyInAction) return;
        player.currentActionPercentage = (TimeHandler.Instance.timeController - player.currentActionStartTime) / (player.currentActionFinishTime - player.currentActionStartTime);
        if (TimeHandler.Instance.timeController < player.currentActionFinishTime) return;
        player.isCurrentlyInAction = false;
        Debug.Log("Ação de " + player.playerName + " terminado");
        finishAction(player); 
    }

    private void finishAction(CharacterHandler player){
        PlaceResources place = player.currentPlace;
        player.isCurrentlyInAction = false;
        switch (player.actionType){
            case ActionType.ImproveDefense:
                eventManager.TriggerEvent("Defense", player, place);
                break;
            case ActionType.Looting:
                eventManager.TriggerEvent("Loot", player, place);
                break;
            case ActionType.ClearDanger:
               eventManager.TriggerEvent("Danger", player, place);
                break;
            case ActionType.Search:
                eventManager.TriggerEvent("Search", player, place);
                break;
            case ActionType.Relax:
                eventManager.TriggerEvent("Relax", player, place);
                break;
            case ActionType.Move:
                player.currentPlace = player.placeToGo;
                break;
            case ActionType.Sleep:
                eventManager.TriggerEvent("Night", player, place);
                break;
        }
        
        if(player.isSelected) UICharacter.Instance.updatePlayerPanel(player);
        
        player.actionType = 0;
        UIHandler.Instance.ForceUpdate();
    }



        public void setForAllPlayersTheCurrentPlace(PlaceResources place){
            foreach(CharacterHandler player in GameManager.Instance.Players){
                player.currentPlace = place;
            }
        }

}


public enum ActionType
{
    None = 0,
    ImproveDefense = 1,
    Looting = 2,
    ClearDanger = 3,
    Search = 4,
    Relax = 5,
    Move = 6,
    Sleep = 7
}
public static class ActionTypeExtensions
{
    public static int GetDuration(this ActionType action, CharacterHandler player)
    {
        int baseDuration = action switch
        {
            ActionType.ImproveDefense => 30,
            ActionType.Looting => 40,
            ActionType.ClearDanger => 25,
            ActionType.Search => 35,
            ActionType.Relax => 20,
            ActionType.Move => 30,
            ActionType.Sleep => 10,
            _ => 30, // Duração padrão para ações desconhecidas
        };

        switch (action)
        {
            case ActionType.Looting when player.characterResources.playerItens.hasFlashlight:
                return baseDuration / 2; 
            case ActionType.Search when player.characterResources.playerItens.hasBinoculars:
                return baseDuration / 2;
            default:
                return baseDuration;
        }
    }
}