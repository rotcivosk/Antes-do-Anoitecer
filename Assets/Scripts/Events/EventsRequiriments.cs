using System;
using UnityEngine;

[Serializable]
public class EventRequirement
{

    public float minPlaceDefense = 0; 
    public float maxPlaceDefense = 100;
    public float minFoodWithPlayer = 0;
    public float minPlayerSanity = 100;
    public float maxPlayerSanity = 100;
    public bool needsOtherCharacterTogether = false;
    public bool requiresCar = false;
    public bool requiresDrink = false;
    public bool requiresMedKit = false;    
    public bool requiresFlashlight = false;
    public bool requiresBinocular = false;
}

[Serializable]
public class EventResult
{

    public float dangerChangeValueBy = 0;
    public float defenseChangeValueBy = 0;
    public float lootingChangeValueBy = 0;
    public float foodChangeValueBy = 0;
    public float sanityChangeValueBy = 0;
    public bool addCar = false;
    public bool loseCar = false;
    public bool addDrink = false;
    public bool loseDrink = false;
    public bool addMedkit = false;
    public bool loseMedkit = false;
    public bool addFlashlight = false;
    public bool loseFlashlight = false;
}