using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class PlaceResources : MonoBehaviour
{
    // Características do lugar
    [SerializeField] float dangerValue;
    [SerializeField] float lootingValue;
    [SerializeField] float defenseValue;
    [SerializeField] string placeName;
    [SerializeField] PlayerHandler[] players; // 0 = Player1, 1 = Player2, 2 = Player3, 3 = Player4
    [SerializeField] bool isVerified;


    // Imagens do lugar
    [SerializeField] Sprite[] placeSelected; // 0 = PlaceSelected, 1 = PlaceUnselected
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer[] miniPlayerSprites; // 0 = Player1, 1 = Player2, 2 = Player3, 3 = Player4
    [SerializeField] Sprite menuImage;
    

    // Referencias pra atualizar a UI
    public UIHandler uiHandler;
    [SerializeField] Vector2 menuPlacePosition; // Posição do miniMenu do lugar na tela ao ser selecionado


    // Pra parte de seleção de lugares
    private float[] minMaxValues =  {0.1f, 0.9f, 0.1f, 0.9f}; // minX, maxX, minY, maxY. Limites da tela clicável
    private bool isInside = false; // Isso parece gambi, mas juro que não é
    public bool isSelected;


    // Pros Setters e Getters
    private float[] minMaxSettingValues = {0, 100} ;





    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = placeSelected[0];
    }

    // Update is called once per frame
    void Update()
    {
            
    }


    // Código para a seleção de Lugares

    void OnMouseOver() { // Só pra checar se tá sobre o item ou não
        Debug.Log("Mouse is over " + placeName);
        if(uiHandler.isThereAPlaceSelected) return;
        Debug.Log("Tem um lugar selecionado: " + uiHandler.isThereAPlaceSelected);
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("Clicou no lugar");
            uiHandler.changeSelectionStatusAllPlaces(this);
        }
    }

    public void PlaceIsSelected() { // Se for fazer mais coisas quando selecionar o local, mexer aqui V 
        uiHandler.UpdatePlaceMiniMenu(this);
        uiHandler.changeMiniMenuPosition(menuPlacePosition);
        spriteRenderer.sprite = placeSelected[0];
        isSelected = true;
    }
    public void PlaceIsUnselected() {
        spriteRenderer.sprite = placeSelected[1];
        isSelected = false;
       
    }




    // Getters and Setters só pq eu quero. Pq não mudou em pn. upd-> Né que até ajudou no final oh.
    // na real que relendo nem tem setters, é só getters e uns que somam valor   

    public string getPlaceName() {
        return placeName;
    }
    public float getDangerValue() {
        return dangerValue;
    }
    public void addDangerValue(float changedValue) {
         dangerValue = Mathf.Clamp(dangerValue + changedValue, minMaxSettingValues[0], minMaxSettingValues[1]);
    }
    public float getLootingValue() {
        return lootingValue;
    }
    public void addLootingValue(float changedValue) {
        lootingValue = Mathf.Clamp(lootingValue + changedValue,  minMaxSettingValues[0], minMaxSettingValues[1]);
    }
    public float getDefenseValue() {
        return defenseValue;
    }
    public void addDefenseValue(float changedValue) {
         defenseValue = Mathf.Clamp(defenseValue + changedValue,  minMaxSettingValues[0], minMaxSettingValues[1]);
    }
    public void setObserves(bool value) {
        isVerified = value;
    }
    public bool getObserves() {
        return isVerified;
    }
    public float getTravelValue(){
        return 60;
    }
    public Sprite GetImage(){
        return menuImage;
    }


    // Para checar onde que o player está. Tou considerando ter 4 Imagens para cada local, e nelas aparecer a imagem do player lá se ele tiver
    public void CheckPlayersInPlace() {
        for (int i = 0; i < players.Length; i++) {
            if (players[i].getCurrentPlace() == this) {
                miniPlayerSprites[i].enabled = true;
                miniPlayerSprites[i].sprite = players[i].getPlayerSprite();
            }
        }
    }





    // Só pra UI
    public Sprite GetPlaceSprite() {
        return menuImage;
    }

}
