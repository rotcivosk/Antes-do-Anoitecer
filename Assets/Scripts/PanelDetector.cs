using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static PanelDetector Instance; // Singleton para o painel
    public bool isOverPanel { get; private set; } = false;
    private void Awake() {
        Instance = this;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isOverPanel = true;
    }
    public void OnPointerExit(PointerEventData eventData) {
        isOverPanel = false;
    }
}