using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIPlace : MonoBehaviour
{
    public static UIPlace Instance;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text lootText;
    [SerializeField] TMP_Text dangerText;
    [SerializeField] TMP_Text defenseText;
    [SerializeField] TMP_Text travelText;
    [SerializeField] TMP_Text timeSearchText;
    [SerializeField] TMP_Text timeLootText;
    [SerializeField] TMP_Text timeDefendText;
    [SerializeField] TMP_Text timeDangerText;
    [SerializeField] TMP_Text timeRelaxText;
    [SerializeField] Image placeImage;
    [SerializeField] PlaceResources startingPlace;
    [SerializeField] GameObject placeMiniMenu;
    private PlaceResources currentPlace;
    private CharacterHandler currentPlayer;
        private void Awake()
    {
        Instance = this;
    }
    public void UpdateMenu(PlaceResources place){
        if (place == null) {
            changeMiniMenuPosition(new Vector2(-2000, 0));
            return;
        }
        currentPlace = place;
        currentPlayer = GameManager.Instance.GetSelectedPlayer();
        UpdateMiniMenuHeaderValues();
        UpdateMiniMenuDurationValues();
        changeMiniMenuPosition(currentPlace.menuPlacePosition);
    }
    
    private void UpdateMiniMenuHeaderValues() {
        SetText(titleText, currentPlace.placeName);
        if (!currentPlace.isVerified) {
            SetText(lootText, "??");
            SetText(dangerText, "??");
            SetText(defenseText, "??");
        } else {
            SetText(lootText, currentPlace.lootingValue.ToString() + "%");
            SetText(dangerText, currentPlace.dangerValue.ToString() + "%");
            SetText(defenseText, currentPlace.defenseValue.ToString() + "%");
        }
        SetText(travelText, currentPlace.getTravelValue().ToString());
        placeImage.sprite = currentPlace.GetPlaceSprite();
    }
    private void UpdateMiniMenuDurationValues() {
        SetText(timeSearchText, GetActionDuration(ActionType.Search));
        SetText(timeLootText, GetActionDuration(ActionType.Looting));
        SetText(timeDefendText, GetActionDuration(ActionType.ImproveDefense));
        SetText(timeDangerText, GetActionDuration(ActionType.ClearDanger));
        SetText(timeRelaxText, GetActionDuration(ActionType.Relax));
    }
    private string GetActionDuration(ActionType action) {
        return action.GetDuration(currentPlayer).ToString();
    }
    private void SetText(TMP_Text textElement, string value) {// Aqui é pra quando der erro, ele não quebrar o código
        if (textElement != null){
            textElement.text = value;
            return;
        } 
        Debug.LogError ("Text element is null"); 
    }
    private void changeMiniMenuPosition(Vector2 position) {
        RectTransform rt = placeMiniMenu.GetComponent<RectTransform>();
        rt.anchoredPosition = position;
    }
}