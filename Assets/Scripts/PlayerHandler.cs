
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHandler : MonoBehaviour
{

    private float playerSanity = 100f;
    public bool isDead = false;
    private PlaceResources placeResources;
    public bool isSelected = false;
    public bool isCurrentlyInAction = false;
    public int actionType = 0; // 0 = Nada, 1 = Aumentar Defesa, 2 = Diminuir Looting, 3 = Diminuir Perigo
    public float currentActionStartTime;
    public float currentActionFinishTime;
    private string playerName;
    [SerializeField] Sprite miniPlayerSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    
    public void setPlaceResources(PlaceResources placeResources){
        this.placeResources = placeResources;
    }

    public PlaceResources getCurrentPlace(){
        return placeResources;
    }

    public string getPlayerName(){
        return playerName;
    }
    public Sprite getPlayerSprite(){
        return miniPlayerSprite;
    }
}
