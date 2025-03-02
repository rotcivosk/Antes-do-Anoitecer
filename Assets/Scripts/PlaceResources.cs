using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.Search;
#endif
using UnityEngine;

public class PlaceResources : MonoBehaviour
{

   private float[] minMaxSettingValues = {0, 100} ;
    // Características do lugar
    [SerializeField] private float _dangerValue; // Quanto tempo leva pra chegar no lugar
    public float dangerValue{
        get => _dangerValue;
        set{
            _dangerValue = Mathf.Clamp(value, minMaxSettingValues[0], minMaxSettingValues[1]);
        }
    }
    [SerializeField] private float _lootingValue; // Quanto tempo leva pra chegar no lugar
    public float lootingValue{
        get => _lootingValue;
        set{
            _lootingValue = Mathf.Clamp(value, 0, 100);
        }
    }
    [SerializeField] private float _defenseValue; // Quanto tempo leva pra chegar no lugar
    public float defenseValue{
        get => _defenseValue;
        set{
            _defenseValue = Mathf.Clamp(value, minMaxSettingValues[0], minMaxSettingValues[1]);
        }
    }
    [SerializeField] private string _placeName; // Nome do Local
    public string placeName{
        get =>_placeName;
        set{
            _placeName = value;
        }
    }
    public bool isVerified {get;set;} = false; // Se o lugar foi verificado ou não
    public bool isMouseOver = false; // Se o mouse está sobre o lugar ou não


    [SerializeField] PlaceImagesHandler placeImagesHandler;
    [SerializeField] public Vector2 menuPlacePosition; // Posição do miniMenu do lugar na tela ao ser selecionado
    [SerializeField] public Vector2[] playerPositions;
    public bool isSelected;
    
    void OnMouseEnter() { 
        isMouseOver = true;
    }
    void OnMouseExit() {
        isMouseOver = false;
    }

    public void SelectPlace() { // Se for fazer mais coisas quando selecionar o local, mexer aqui V 
        placeImagesHandler.UpdateSelection(true);
        isSelected = true;
    }
    public void UnselectPlace() {
        placeImagesHandler.UpdateSelection(false);
        isSelected = false;
    }
    public float getTravelValue(){
        return 60;
    }
    public Sprite GetPlaceSprite() {
        return placeImagesHandler.menuImage;
    }

}
