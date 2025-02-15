using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    
    [SerializeField] Image playerIconImage;
    [SerializeField] Image playerSanityBar;
    [SerializeField] Image playerActionBar;
    [SerializeField] Image placeIconImage;
    [SerializeField] PlayerHandler currentPlayer;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text playerLocationText;
    [SerializeField] PlayerHandler startingPlayer;

    [SerializeField] PlayerHandler[] players; // Isso está sendo uma gambi para deselecionar depois de selecionar

    void Start()
    {
        currentPlayer = startingPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }


    public void setPlayerHandler(PlayerHandler playerHandler){
        this.currentPlayer = playerHandler;
        changeSelectionStatusAllPlayers();
        Debug.Log("Player " + currentPlayer.playerName + " is selected");
        updateCurrentPlayerTexts();
    }
    public void updateUI(){
        updateSanityBar();
        updateActionBar();
        updateCurrentPlayerTexts(); // Tenho quase certeza que isso daqui tá errado, fazer esse check a cada update. Mas OK
    }

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




    private void updateCurrentPlayerTexts(){
        playerNameText.text = currentPlayer.getPlayerName();
        playerLocationText.text = currentPlayer.getPlaceName();
        playerIconImage.sprite = currentPlayer.miniPlayerSprite;
        placeIconImage.sprite = currentPlayer.getPlaceSprite();
    }

    void updateSanityBar(){
        playerSanityBar.fillAmount = currentPlayer.getSanity()/100;
    }

    void updateActionBar(){
        if (currentPlayer.isCurrentlyInAction){
            playerActionBar.fillAmount = currentPlayer.currentActionPercentage;
        } else{
            playerActionBar.fillAmount = 100;
        }
    }
}
