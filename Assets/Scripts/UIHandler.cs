using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text[] placeTexts; // 0 = Título, 1 = Perigo, 2 = Loot, 3 = Defesa

    [SerializeField] TMP_Text[] testTexts; // 0~2 = Place1, 3~5 = Place2, 6~8 = Place3, 9~11 = Place4

    [SerializeField] PlaceResources place1;
    [SerializeField] PlaceResources place2;
    [SerializeField] PlaceResources place3;
    [SerializeField] PlaceResources place4;
    public TimeHandler timeHandler;
    [SerializeField] TMP_Text textTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        updateTempTexts(); //Só pra testar
        updateTime();
    }

    void updateTempTexts(){ //Só pra testar
        testTexts[0].text = place1.getDangerValue().ToString();
        testTexts[1].text = place1.getLootingValue().ToString();
        testTexts[2].text = place1.getDefenseValue().ToString();
        testTexts[3].text = place2.getDangerValue().ToString();
        testTexts[4].text = place2.getLootingValue().ToString();
        testTexts[5].text = place2.getDefenseValue().ToString();
        testTexts[6].text = place3.getDangerValue().ToString();
        testTexts[7].text = place3.getLootingValue().ToString();
        testTexts[8].text = place3.getDefenseValue().ToString();
        testTexts[9].text = place4.getDangerValue().ToString();
        testTexts[10].text = place4.getLootingValue().ToString();
        testTexts[11].text = place4.getDefenseValue().ToString();

    }

    void updateTime(){
        textTime.text = timeHandler.timeController.ToString();
    }

    public void UpdatePlaceMiniMenu(PlaceResources place){
        placeTexts[0].text = place.getPlaceName();
        placeTexts[1].text = place.getDangerValue().ToString();
        placeTexts[2].text = place.getLootingValue().ToString();
        placeTexts[3].text = place.getDefenseValue().ToString();
    }
}
