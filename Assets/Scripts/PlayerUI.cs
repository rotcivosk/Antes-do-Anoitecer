using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    
    [SerializeField]  Image playerIconImage;
    [SerializeField]  Image playerSanityBar;
    [SerializeField] PlayerHandler playerHandler;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateUI(){
        updateSanityBar();
    }

    void updateSanityBar(){
        playerSanityBar.fillAmount = playerHandler.getSanity()/100;
    }
}
