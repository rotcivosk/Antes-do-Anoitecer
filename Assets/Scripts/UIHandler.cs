using UnityEngine;
public class UIHandler : MonoBehaviour
{

    // Colocar aqui todas as informações de todas as partes de UI
    public static UIHandler Instance { get; private set; }
    [SerializeField] private CharacterHandler _currentPlayer;
    public CharacterHandler currentPlayer {set;get;}
    [SerializeField] CharacterHandler startingPlayer;
    void Start()
    {
        currentPlayer = startingPlayer;
        ChangePlayerSelected(startingPlayer);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void ChangePlayerSelected(CharacterHandler newPlayer){
        currentPlayer = newPlayer;
        UICharacter.Instance.updatePlayerPanel(currentPlayer);
    }
    public void ForceUpdate(){
    }

    public void UpdatedEverySecond(){
        UICharacter.Instance.updateEverySecond();
        UITime.Instance.UpdateTimeUI();
    }




}



    
    