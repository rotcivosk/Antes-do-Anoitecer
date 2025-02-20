using UnityEngine;


// Alterações de Local

[CreateAssetMenu(fileName = "SetPlaceAsSeen", menuName = "Game/Effects/SetPlaceAsSeen")]
public class SetPlaceAsSeen : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("SetPlaceAsSeen");
        place.setObserves(true);
    }
}

[CreateAssetMenu(fileName = "AddPlaceDefense", menuName = "Game/Effects/AddPlaceDefense")]
public class AddPlaceDefense : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {

        place.addDefenseValue(10);
    }
}

[CreateAssetMenu(fileName = "AddPlaceDefense+", menuName = "Game/Effects/AddPlaceDefense+")]
public class AddPlaceDefenseLarge : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("AddPlaceDefenseLarge");
        place.addDefenseValue(20);
    }
}

[CreateAssetMenu(fileName = "RemovePlaceDefense", menuName = "Game/Effects/RemovePlaceDefense")]
public class RemovePlaceDefense : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemovePlaceDefense");
        place.addDefenseValue(-10);
    }
}

[CreateAssetMenu(fileName = "RemovePlaceDefense+", menuName = "Game/Effects/RemovePlaceDefense+")]
public class RemovePlaceDefenseLarge : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemovePlaceDefenseLarge");
        place.addDefenseValue(-25);
    }
}

[CreateAssetMenu(fileName = "RemovePlaceDefenseAll", menuName = "Game/Effects/RemovePlaceDefenseAll")]
public class RemovePlaceDefenseAll : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemovePlaceDefenseAll");
        place.addDefenseValue(-100);
    }
}

[CreateAssetMenu(fileName = "RemovePlaceLoot", menuName = "Game/Effects/RemovePlaceLoot")]
public class RemovePlaceLoot : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemovePlaceLoot");
        place.addLootingValue(-10);
        
    }
}

[CreateAssetMenu(fileName = "RemovePlaceLoot+", menuName = "Game/Effects/RemovePlaceLoot+")]
public class RemovePlaceLootLarge : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemovePlaceLootLarge");
        place.addLootingValue(-15);
    }
}

[CreateAssetMenu(fileName = "RemovePlaceLootAll", menuName = "Game/Effects/RemovePlaceLootAll")]
public class RemovePlaceLootAll : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemovePlaceLootAll");
        place.addLootingValue(-100);
    }
}



// Alterações de Itens do Jogador
[CreateAssetMenu(fileName = "AddMedKit", menuName = "Game/Effects/AddMedKit")]
public class AddMedKit : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("AddMedKit");
        player.setMedkit(true);
    }
}

[CreateAssetMenu(fileName = "RemoveMedKit", menuName = "Game/Effects/RemoveMedKit")]
public class RemoveMedKit : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveMedKit");
        player.setMedkit(false);
    }
}

[CreateAssetMenu(fileName = "AddFlashlight", menuName = "Game/Effects/AddFlashlight")]
public class AddFlashlight : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("AddFlashlight");
        player.setFlashlight(true);
    }
}

[CreateAssetMenu(fileName = "RemoveFlashlight", menuName = "Game/Effects/RemoveFlashlight")]
public class RemoveFlashlight : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveFlashlight");
        player.setFlashlight(false);
    }
}

[CreateAssetMenu(fileName = "AddDrink", menuName = "Game/Effects/AddDrink")]
public class AddDrink : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("AddDrink");
        player.setBeer(true);
    }
}

[CreateAssetMenu(fileName = "RemoveDrink", menuName = "Game/Effects/RemoveDrink")]
public class RemoveDrink : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveDrink");
        player.setBeer(false);
    }
}
[CreateAssetMenu(fileName = "AddCar", menuName = "Game/Effects/AddCar")]
public class AddCar : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("AddCar");
        player.setCar(true);
    }
}

[CreateAssetMenu(fileName = "RemoveCar", menuName = "Game/Effects/RemoveCar")]
public class RemoveCar : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveCar");
        player.setCar(false);
    }
}



// Alterações de Comida




[CreateAssetMenu(fileName = "AddFoodForPlayer", menuName = "Game/Effects/AddFoodForPlayer")]
public class AddFoodForPlayer : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("AddFoodForPlayer");
        player.updateFood(1);
    }
}

[CreateAssetMenu(fileName = "AddFoodForPlayer+", menuName = "Game/Effects/AddFoodForPlayer+")]
public class AddFoodForPlayerLarge : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("AddFoodForPlayerLarge");
        player.updateFood(2);
    }
}

[CreateAssetMenu(fileName = "RemoveFoodForPlayer", menuName = "Game/Effects/RemoveFoodForPlayer")]
public class RemoveFoodForPlayer : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveFoodForPlayer");
        player.updateFood(-1);
    }
}

[CreateAssetMenu(fileName = "RemoveFoodForPlayer+", menuName = "Game/Effects/RemoveFoodForPlayer+")]
public class RemoveFoodForPlayerLarge : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveFoodForPlayerLarge");
        player.updateFood(-2);
    }
}


// Alterações de Sanidade
[CreateAssetMenu(fileName = "RemoveSanity", menuName = "Game/Effects/RemoveSanity")]
public class RemoveSanity : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveSanity");
        player.addSanity(-10);
    }
}

[CreateAssetMenu(fileName = "RemoveSanity+", menuName = "Game/Effects/RemoveSanity+")]
public class RemoveSanityLarge : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveSanityLarge");
        player.addSanity(-15);
    }
}

[CreateAssetMenu(fileName = "RemoveSanity++", menuName = "Game/Effects/RemoveSanity++")]
public class RemoveSanityExtraLarge : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("RemoveSanityExtraLarge");
        player.addSanity(-20);
    }
}

[CreateAssetMenu(fileName = "Nothing", menuName = "Game/Effects/Nothing")]
public class Nothing : ScriptableObject, IActionEffect
{
    public void Apply(PlayerHandler player, PlaceResources place)
    {
        Debug.Log("Nothing happens");
    }
}


