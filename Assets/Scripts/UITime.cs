using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UITime : MonoBehaviour
{
    public static UITime Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else{
            Destroy(gameObject);
        }
    }
    [SerializeField] TMP_Text textTime;
    [SerializeField] TMP_Text textDay;
    [SerializeField] Image IconSunMoon;
    [SerializeField] Sprite sunSprite;
    [SerializeField] Sprite moonSprite;
    public void UpdateTimeUI(){
        textTime.text = TimeHandler.Instance.timeAsString;
        textDay.text = TimeHandler.Instance.dayValue.ToString();
    }
    public void updateNightUI(bool isDay) {
        if (isDay){
            IconSunMoon.sprite = sunSprite;
        } else {
            IconSunMoon.sprite = moonSprite;
        }
    }
}