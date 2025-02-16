using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{

    // Colocar aqui todas as informações de todas as partes de UI



    // Panel de Locais
    [SerializeField] TMP_Text[] placeTexts; // 0 = Título, 1 = Loot, 2 = Danger, 3 = Defesa, 4 = Viagem
    [SerializeField] Image placeImage;
    [SerializeField] GameObject placeMiniMenu;
    
    
    
    public TimeHandler timeHandler;
    [SerializeField] TMP_Text textTime;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
    }



    void updateTime(){
        textTime.text = timeHandler.timeAsString;
    }


    // Update das infos do Panel de Locais
    public void UpdatePlaceMiniMenu(PlaceResources place){
        placeTexts[0].text = place.getPlaceName();
        placeTexts[1].text = place.getLootingValue().ToString() + "%";
        placeTexts[2].text = place.getDangerValue().ToString() + "%";
        placeTexts[3].text = place.getDefenseValue().ToString() + "%";
        placeTexts[4].text = place.getTravelValue().ToString();
        placeImage.sprite = place.GetImage();
    }

    public void changeMiniMenuPosition(Vector2 position){
        RectTransform rt = placeMiniMenu.GetComponent<RectTransform>();
        rt.anchoredPosition = position;
    }






}
