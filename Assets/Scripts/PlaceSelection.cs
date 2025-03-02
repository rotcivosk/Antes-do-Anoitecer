using System.Collections;
using UnityEngine;

public class PlaceSelection : MonoBehaviour
{
    private float delayForDeselect = 0.1f;
    private bool isOverPanel = false;
    private bool isThereAPlaceSelected = false;
    private PlaceResources selectedPlace;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            CheckForCliking();
        }
    }
    public void CheckForCliking() {
        Debug.Log("Checando clique");
        selectedPlace = GameManager.Instance.GetMouseOverPlace();
        Debug.Log("Selecionou o local " + selectedPlace);
        PlaceResources place = GameManager.Instance.GetSelectedPlace();
        Debug.Log("Local selecionado " + place);
        isThereAPlaceSelected = place != null;   
        Debug.Log("Tem um local selecionado? " + isThereAPlaceSelected);
        isOverPanel = PanelDetector.Instance.isOverPanel;
        Debug.Log("Está sobre o painel? " + isOverPanel);
        if (isThereAPlaceSelected && isOverPanel) return;
        if (isThereAPlaceSelected && !isOverPanel){ 
            Debug.Log("Selecionou um local e não está sobre o painel, deselecionando tudo");
            deselectAllPlaces();
            return;
        }
        Debug.Log("SelectedPlace é nulo? " + selectedPlace);
        if (selectedPlace == null) return;
        Debug.Log("Selecionou um local");
        selectPlaceAndUnselectTheRest();
    }
    public void selectPlaceAndUnselectTheRest(){
        foreach (PlaceResources place in GameManager.Instance.Places) {
            if (place == selectedPlace) {
                place.SelectPlace();
            } else {
                place.UnselectPlace();
            }
        }
        DelayThenChangeSelection(true);
        UIPlace.Instance.UpdateMenu(selectedPlace);

    }
    public void deselectAllPlaces(){
        foreach (PlaceResources place in GameManager.Instance.Places) place.UnselectPlace();
        DelayThenChangeSelection(false);
        UIPlace.Instance.UpdateMenu(null);

    }
    private void DelayThenChangeSelection(bool newisThereAPlaceSelected) {
        StartCoroutine(DeselectAfterDelay(newisThereAPlaceSelected));
    }

    private IEnumerator DeselectAfterDelay(bool newisThereAPlaceSelected) {
        yield return new WaitForSeconds(delayForDeselect);
        isThereAPlaceSelected = newisThereAPlaceSelected;
    }
}
