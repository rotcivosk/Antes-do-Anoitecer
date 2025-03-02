using UnityEngine;

public class CharacterResources : MonoBehaviour
{
    //[SerializeField] public PlayerHandler playerHandler;
    [SerializeField] public PlayerItens playerItens;
    [SerializeField] private int _playerFood = 2;
    public int playerFood {        
        get => _playerFood;
        set => _playerFood = Mathf.Clamp(value, 0, 10);
    }
    [SerializeField] private float _playerSanity = 100f;
    public float playerSanity {        
        get => _playerSanity;
        set {
            _playerSanity = Mathf.Clamp(value, 0, 100);
            if (_playerSanity == 0) {
;           }
        }
    }

}


[System.Serializable]
public class PlayerItens{
    public bool hasCar = false;
    public bool hasBeer = false;
    public bool hasMedkit = false;
    public bool hasFlashlight = false;
    public bool hasBinoculars = false;
}
