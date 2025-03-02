using UnityEngine;


// Alterações de Local

[CreateAssetMenu(fileName = "SetPlaceAsSeen", menuName = "Game/Effects/SetPlaceAsSeen")]
public class SetPlaceAsSeen : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("SetPlaceAsSeen");
        place.isVerified = true;
    }
}

[CreateAssetMenu(fileName = "AddPlaceDefense", menuName = "Game/Effects/AddPlaceDefense")]
public class AddPlaceDefense : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.defenseValue += 10;
    }
}

[CreateAssetMenu(fileName = "AddPlaceDefense+", menuName = "Game/Effects/AddPlaceDefense+")]
public class AddPlaceDefenseLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.defenseValue += 20;
    }
}

[CreateAssetMenu(fileName = "RemovePlaceDefense", menuName = "Game/Effects/RemovePlaceDefense")]
public class RemovePlaceDefense : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.defenseValue -= 10;
    }
}

[CreateAssetMenu(fileName = "RemovePlaceDefense+", menuName = "Game/Effects/RemovePlaceDefense+")]
public class RemovePlaceDefenseLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.defenseValue -= 25;
    }
}

[CreateAssetMenu(fileName = "RemovePlaceDefenseAll", menuName = "Game/Effects/RemovePlaceDefenseAll")]
public class RemovePlaceDefenseAll : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.defenseValue = 0;
    }
}

[CreateAssetMenu(fileName = "RemovePlaceLoot", menuName = "Game/Effects/RemovePlaceLoot")]
public class RemovePlaceLoot : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.lootingValue -= 10;
       
    }
}

[CreateAssetMenu(fileName = "RemovePlaceLoot+", menuName = "Game/Effects/RemovePlaceLoot+")]
public class RemovePlaceLootLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.lootingValue -= 15;
    }
}

[CreateAssetMenu(fileName = "RemovePlaceLootAll", menuName = "Game/Effects/RemovePlaceLootAll")]
public class RemovePlaceLootAll : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        place.lootingValue = 0;
    }
}
// Alterações de Itens do Jogador
[CreateAssetMenu(fileName = "AddMedKit", menuName = "Game/Effects/AddMedKit")]
public class AddMedKit : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddMedKit");
        player.characterResources.playerItens.hasMedkit = true;
    }
}

[CreateAssetMenu(fileName = "RemoveMedKit", menuName = "Game/Effects/RemoveMedKit")]
public class RemoveMedKit : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveMedKit");
        player.characterResources.playerItens.hasMedkit = false;
    }
}

[CreateAssetMenu(fileName = "AddFlashlight", menuName = "Game/Effects/AddFlashlight")]
public class AddFlashlight : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddFlashlight");
        player.characterResources.playerItens.hasFlashlight = true;
    }
}

[CreateAssetMenu(fileName = "RemoveFlashlight", menuName = "Game/Effects/RemoveFlashlight")]
public class RemoveFlashlight : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveFlashlight");
        player.characterResources.playerItens.hasFlashlight = false;
    }
}

[CreateAssetMenu(fileName = "AddDrink", menuName = "Game/Effects/AddDrink")]
public class AddDrink : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddDrink");
        player.characterResources.playerItens.hasBeer = true;
    }
}

[CreateAssetMenu(fileName = "RemoveDrink", menuName = "Game/Effects/RemoveDrink")]
public class RemoveDrink : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveDrink");
        player.characterResources.playerItens.hasBeer = false;
    }
}

[CreateAssetMenu(fileName = "AddCar", menuName = "Game/Effects/AddCar")]
public class AddCar : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddCar");
        player.characterResources.playerItens.hasCar = true;
    }
}

[CreateAssetMenu(fileName = "RemoveCar", menuName = "Game/Effects/RemoveCar")]
public class RemoveCar : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveCar");
        player.characterResources.playerItens.hasCar = false;
    }
}


// Alterações de Comida




[CreateAssetMenu(fileName = "AddFoodForPlayer", menuName = "Game/Effects/AddFoodForPlayer")]
public class AddFoodForPlayer : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddFoodForPlayer");
        player.characterResources.playerFood += 1;
    }
}

[CreateAssetMenu(fileName = "AddFoodForPlayer+", menuName = "Game/Effects/AddFoodForPlayer+")]
public class AddFoodForPlayerLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddFoodForPlayerLarge");
       player.characterResources.playerFood += 2;
    }
}

[CreateAssetMenu(fileName = "RemoveFoodForPlayer", menuName = "Game/Effects/RemoveFoodForPlayer")]
public class RemoveFoodForPlayer : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveFoodForPlayer");
        player.characterResources.playerFood -= 1;
    }
}

[CreateAssetMenu(fileName = "RemoveFoodForPlayer+", menuName = "Game/Effects/RemoveFoodForPlayer+")]
public class RemoveFoodForPlayerLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveFoodForPlayerLarge");
        player.characterResources.playerFood -= 2;
    }
}


// Alterações de Sanidade
[CreateAssetMenu(fileName = "RemoveSanity", menuName = "Game/Effects/RemoveSanity")]
public class RemoveSanity : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveSanity");
        player.characterResources.playerFood -= 10;
    }
}

[CreateAssetMenu(fileName = "RemoveSanity+", menuName = "Game/Effects/RemoveSanity+")]
public class RemoveSanityLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveSanityLarge");
        player.characterResources.playerSanity-= 15;
    }
}

[CreateAssetMenu(fileName = "RemoveSanity++", menuName = "Game/Effects/RemoveSanity++")]
public class RemoveSanityExtraLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("RemoveSanityExtraLarge");
        player.characterResources.playerSanity-= 20;
    }
}
[CreateAssetMenu(fileName = "AddSanity", menuName = "Game/Effects/AddSanity")]
public class AddSanity : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddSanity");
        player.characterResources.playerSanity+= 10;
    }
}
[CreateAssetMenu(fileName = "AddSanity+", menuName = "Game/Effects/AddSanity+")]
public class AddSanityLarge : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("AddSanity");
        player.characterResources.playerSanity+= 20;
    }
}

[CreateAssetMenu(fileName = "Nothing", menuName = "Game/Effects/Nothing")]
public class Nothing : ScriptableObject, IActionEffect
{
    public void Apply(CharacterHandler player, PlaceResources place)
    {
        Debug.Log("Nothing happens");
    }
}


