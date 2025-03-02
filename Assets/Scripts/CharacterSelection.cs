using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterSelection : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CharacterHandler selectedPlayer;
    public void OnPointerClick(PointerEventData eventData)
    {
        UIHandler.Instance.ChangePlayerSelected(selectedPlayer);
        changeSelectionStatusAllPlayers();
    }
    public void changeSelectionStatusAllPlayers(){
        foreach (CharacterHandler player in GameManager.Instance.Players) {
            if (player == selectedPlayer) {
                player.isSelected = true;
            } else{
                player.isSelected = false;
            }
        }
    }
}
