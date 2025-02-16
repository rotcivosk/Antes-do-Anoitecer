using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class buttonsActions : MonoBehaviour
{
    [SerializeField] PlaceResources[] places; // 0 = Place1, 1 = Place2, 2 = Place3, 3 = Place4
    [SerializeField] PlayerHandler[] players; // 0 = Player1, 1 = Player2, 2 = Player3, 3 = Player4
    [SerializeField] ActionsHandler actionsHandler;

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
                return places[i];
            }
        }
        return null;
    }   


}
