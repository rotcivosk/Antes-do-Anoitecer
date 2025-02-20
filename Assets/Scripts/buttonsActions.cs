using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.EventSystems;

public class buttonsActions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] PlaceResources[] places; // 0 = Place1, 1 = Place2, 2 = Place3, 3 = Place4
    [SerializeField] PlayerHandler[] players; // 0 = Player1, 1 = Player2, 2 = Player3, 3 = Player4
    [SerializeField] ActionsHandler actionsHandler;
    public bool isOverPanel = false;
    [SerializeField] UIHandler uiHandler;

    //private float delayForDeselect = 0.1f;
    

    void Update()
    {
        CheckForCliking();
    }


    // Checar os botões
    public void actionDefense(){
        actionsHandler.ImproveDefense(getPlaceSelected(), getPlayerSelected());
    }
    public void actionLoot(){
        actionsHandler.StartLooting(getPlaceSelected(), getPlayerSelected());
    }
    public void actionDanger(){
        actionsHandler.ClearDanger(getPlaceSelected(), getPlayerSelected());
    }

    public void actionMove(){
        actionsHandler.MovePlayer(getPlaceSelected(), getPlayerSelected());
    }
    public void actionRelax(){
        actionsHandler.RelaxInPlace(getPlaceSelected(), getPlayerSelected());
    }

    public void actionObserve(){
        actionsHandler.ObservePlace(getPlaceSelected(), getPlayerSelected());
    }

    // Pegar os itens que estão selecionados
    private PlayerHandler getPlayerSelected(){
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].isSelected)
            {
                return players[i];
            }
        }
        return null;
    }
    private PlaceResources getPlaceSelected(){
        for (int i = 0; i < places.Length; i++)
        {
            if (places[i].isSelected)
            {
                Debug.Log(places[i].getPlaceName());
                return places[i];
            }
        }
        return null;
    }   



    // Mover o painel se não tiver nada selecionado

    public void OnPointerEnter(PointerEventData eventData)
    {

        isOverPanel = true;
                Debug.Log("Mouse is over Panel and isOverPanel is now" + isOverPanel);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        isOverPanel = false;
                Debug.Log("Mouse is not over Panel and isOverPanel is now" + isOverPanel);
    }

    public void CheckForCliking(){
        if(uiHandler.isThereAPlaceSelected)
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                if (!isOverPanel){
                    Debug.Log("Deselecionou tudo");
                    uiHandler.deselectAllPlaces();
            }
        }
    }




}
