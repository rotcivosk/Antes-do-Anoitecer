using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UICharacter : MonoBehaviour
{
    public static UICharacter Instance { get; private set; }

    [SerializeField] Image playerIconImage;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text playerFoodAmount;
    [SerializeField] Image playerSanityBar;
    [SerializeField] TMP_Text playerSanityText;
    [SerializeField] Image placeWherePlayerIsImage;
    [SerializeField] TMP_Text playerCurrentAction;
    [SerializeField] Image[] playerCurrentItems; // 0 = Car, 1 = Beer, 2 = Medkit, 3 = Flashlight, 4 = Binoculars
    [SerializeField] Image playerActionBar;
    private CharacterResources characterResources;
    private CharacterHandler playerHandler;
    private void Awake()
    {
        Instance = this;
    }
    public void updatePlayerPanel(CharacterHandler currentPlayer){
        playerHandler = currentPlayer;
        characterResources = playerHandler.characterResources;
        updateCurrentPlayerTexts();
        UpdateCurrentPlayerItems();
        updateEverySecond();
    }

    public void updateEverySecond(){
        updateSanityBar();
        updateActionBar();
    }
    public void updateCurrentPlayerTexts() {
        // Header
        playerIconImage.sprite = playerHandler.playerImages.playerSprite;
        playerNameText.text = playerHandler.playerName;
        playerFoodAmount.text = "x" + characterResources.playerFood.ToString();
        // Body
        placeWherePlayerIsImage.sprite = playerHandler.getPlaceSprite();
        playerCurrentAction.text = playerHandler.getCurrentAction();

    }
    public void UpdateCurrentPlayerItems() {
        bool[] playerItems = {
            characterResources.playerItens.hasCar,
            characterResources.playerItens.hasBeer,
            characterResources.playerItens.hasMedkit,
            characterResources.playerItens.hasFlashlight,
            characterResources.playerItens.hasBinoculars
        };
        for (int i = 0; i < playerCurrentItems.Length; i++) {
            playerCurrentItems[i].gameObject.SetActive(playerItems[i]);
        }
    }
    public void updateSanityBar() {
        Debug.Log("Updating Sanity Bar");
        Debug.Log(characterResources.playerSanity);
        playerSanityBar.fillAmount = characterResources.playerSanity / 100;
        playerSanityText.text = characterResources.playerSanity.ToString() + "%";       
    }
    public void updateActionBar() {
        if (playerHandler.isCurrentlyInAction){
            playerActionBar.fillAmount = playerHandler.currentActionPercentage;
        } else{
            playerActionBar.fillAmount = 100;
        }
    }
}
