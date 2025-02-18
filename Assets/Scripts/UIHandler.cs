using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{

    // Colocar aqui todas as informações de todas as partes de UI

    // Paineis de tudo
    public PlacePanelUI placePanelUI;
    public PlayerHeaderPanelUI playerHeaderPanelUI;
    public PlayerBodyPanelUI playerBodyPanelUI;
    public TimeUI timeUI;
    [SerializeField] PlayerHandler currentPlayer;
    [SerializeField] PlayerHandler startingPlayer;
    [SerializeField] PlayerHandler[] players; // Isso está sendo uma gambi para deselecionar depois de selecionar

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = startingPlayer;
        
        updatePlayerPanel(currentPlayer);
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    // Controlador de quando será atualizado tudo
    public void UpdatedEverySecond(){
        timeUI.textTime.text = timeUI.timeHandler.timeAsString;
        updateActionBar(currentPlayer);
    }


    // Panel de Locais
    public void UpdatePlaceMiniMenu(PlaceResources place){
        placePanelUI.placeTexts[0].text = place.getPlaceName();
        placePanelUI.placeTexts[1].text = place.getLootingValue().ToString() + "%";
        placePanelUI.placeTexts[2].text = place.getDangerValue().ToString() + "%";
        placePanelUI.placeTexts[3].text = place.getDefenseValue().ToString() + "%";
        placePanelUI.placeTexts[4].text = place.getTravelValue().ToString();
        placePanelUI.placeImage.sprite = place.GetImage();
    }
    public void changeMiniMenuPosition(Vector2 position){
        RectTransform rt = placePanelUI.placeMiniMenu.GetComponent<RectTransform>();
        rt.anchoredPosition = position;
    }


    // Panel de Player
    public void updatePlayerPanel(PlayerHandler currentPlayer){
        updateCurrentPlayerTexts(currentPlayer);
        updateCurrentPlayerItens(currentPlayer);
    }
    public void updateCurrentPlayerTexts(PlayerHandler currentPlayer){
        Debug.Log("Current Player: " + currentPlayer.getPlayerName());
        // Header
        playerHeaderPanelUI.playerIconImage.sprite = currentPlayer.miniPlayerSprite;
        playerHeaderPanelUI.playerNameText.text = currentPlayer.getPlayerName();
        playerHeaderPanelUI.playerFoodAmount.text = "x" + currentPlayer.getFoodValue().ToString();
        updateSanityBar(currentPlayer);

        // Body
        playerBodyPanelUI.placeWherePlayerIsImage.sprite = currentPlayer.getPlaceSprite();
        playerBodyPanelUI.playerCurrentAction.text = currentPlayer.getCurrentAction();
        updateCurrentPlayerItens(currentPlayer);
        updateActionBar(currentPlayer);
    }
    public void updateCurrentPlayerItens(PlayerHandler currentPlayer){
        if (currentPlayer.getCar()) playerBodyPanelUI.playerCurrentItems[0].color = Color.white;
            else playerBodyPanelUI.playerCurrentItems[0].color = Color.black;
        if (currentPlayer.getBeer()) playerBodyPanelUI.playerCurrentItems[1].color = Color.white;
            else playerBodyPanelUI.playerCurrentItems[1].color = Color.black;
        if (currentPlayer.getMedkit()) playerBodyPanelUI.playerCurrentItems[2].color = Color.white;
            else playerBodyPanelUI.playerCurrentItems[2].color = Color.black;
        if (currentPlayer.getFlashlight()) playerBodyPanelUI.playerCurrentItems[3].color = Color.white;
            else playerBodyPanelUI.playerCurrentItems[3].color = Color.black;
        if (currentPlayer.getBinoculars()) playerBodyPanelUI.playerCurrentItems[4].color = Color.white;
            else playerBodyPanelUI.playerCurrentItems[4].color = Color.black;
    }

    public void updateSanityBar(PlayerHandler currentPlayer){
        playerHeaderPanelUI.playerSanityBar.fillAmount = currentPlayer.getSanity() / 100;
    }
    public void updateActionBar(PlayerHandler currentPlayer){
            if (currentPlayer.isCurrentlyInAction){
            playerBodyPanelUI.playerActionBar.fillAmount = currentPlayer.currentActionPercentage;
        } else{
            playerBodyPanelUI.playerActionBar.fillAmount = 100;
        }
    
    }


    // Definir qual personagem que fica na tela
    public void setPlayerHandler(PlayerHandler playerHandler){
        currentPlayer = playerHandler;
        changeSelectionStatusAllPlayers();
        //Debug.Log("Player " + currentPlayer.playerName + " is selected");
        updatePlayerPanel(currentPlayer);
    }





    // Isso não deveria estar aqui, tem que tirar
    public void changeSelectionStatusAllPlayers(){
        foreach (PlayerHandler player in players)
        {
            if (player == currentPlayer) {
                player.isSelected = true;
            } else{
                player.isSelected = false;
            }
        }
    }




}

[System.Serializable]
public class PlacePanelUI
{
    public TMP_Text[] placeTexts; // 0 = Título, 1 = Loot, 2 = Danger, 3 = Defesa, 4 = Viagem
    public Image placeImage;
    public GameObject placeMiniMenu;
    public PlaceResources startingPlace;
}

[System.Serializable]
public class PlayerHeaderPanelUI
{   
    // Panel de Players
    public Image playerIconImage;
    public TMP_Text playerNameText;
    public TMP_Text playerFoodAmount;
    public Image playerSanityBar;

}
[System.Serializable]
public class PlayerBodyPanelUI
{   
    // Panel de Players
    public Image placeWherePlayerIsImage;
    public TMP_Text playerCurrentAction;
    public Image[] playerCurrentItems; // 0 = Car, 1 = Beer, 2 = Medkit, 3 = Flashlight, 4 = Binoculars
    public Image playerActionBar;
}

[System.Serializable]
public class TimeUI
{
    public TimeHandler timeHandler;
    public TMP_Text textTime;
}
    
    
    