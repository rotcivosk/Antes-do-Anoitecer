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
        CheckforSelectPlace();
    }


    // Código para a seleção de Lugares
    void CheckforSelectPlace() {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Vector3 mousePos = Input.mousePosition;

            // Checa se está clicando na tela "clicável"
            float mousePosXpercent = mousePos.x/Screen.width;
            float mousePosYpercent = mousePos.y/Screen.height;

            if (mousePosXpercent < minMaxValues[0] || mousePosXpercent > minMaxValues[1]) return;
            if (mousePosYpercent < minMaxValues[2] || mousePosYpercent > minMaxValues[3]) return;

            // Seleciona quem tá em cima, deseleciona quem não tá
            if (isInside) {
                PlaceIsSelected();
            } else {
                PlaceIsUnselected();
            }	
        }
    }
    void OnMouseOver() { // Só pra checar se tá sobre o item ou não
        isInside = true;
    }
    void OnMouseExit() {
        isInside = false;
    }
    void PlaceIsSelected() { // Se for fazer mais coisas quando selecionar o local, mexer aqui V 
        uiHandler.UpdatePlaceMiniMenu(this);
        uiHandler.changeMiniMenuPosition(menuPlacePosition);
        spriteRenderer.sprite = placeSelected[0];
        isSelected = true;
    }
    void PlaceIsUnselected() {
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
    
    public float getTravelValue(){
        return 1;
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
        return spriteRenderer.sprite;
    }

}
