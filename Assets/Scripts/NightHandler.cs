using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightHandler : MonoBehaviour
{
    [SerializeField] PlayerHandler[] players;
    [SerializeField] PlaceResources[] places;
    [SerializeField] UIHandler uiHandler;
    [SerializeField] TimeHandler timeHandler;
    [SerializeField] ActionsHandler actionsHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNight()
    {
        Debug.Log("A noite começou");
        HandleTimeAndUI();
        updatePlayers();
    }

    void HandleTimeAndUI()
    {
        timeHandler.resumeTime();
        uiHandler.updateNightUI(false);
    }



    void updatePlayers()
    {
        foreach (PlayerHandler player in players)
        {
            player.isCurrentlyInAction = false;
        }
        foreach (PlayerHandler player in players)
        {
            actionsHandler.SleepThroughtNight(player);
        }
    }

    public void EndNight()
    {
        Debug.Log("A noite acabou");
        HandleTimeAndUI();
        uiHandler.updateNightUI(true);
    }
 
    /* O que deveria acontecer:
    - O dia para de contar -> OK
    - Acontece algum efeito para dizer que anoitecer
    - Muda o ícone de dia para noite -> OK
    - Para cada jogador, para as ações que estiverem sendo feitas. -> OK
    - Para cada jogador, puxa uma carta de "Noite"
    - Para cada jogador, puxa a carta de "Comida"
    - Conbatiliza os jogadores que perderam comida e ficaram com fome
    - Passa o horário bem rápido até as 06h da manhã
    - Muda o ícone para dia
    - Volta a contar o tempo
    */




}
