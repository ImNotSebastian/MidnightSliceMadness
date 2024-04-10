/*
Note: 
Removing virtual from GetPrefabAssetPath() is set up so that
it changes something on the screen but GetPizzaType()
is set up so that it does not change anything visually
when virtual is removed
*/

///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pizza Super Class

public class CrudePizza
{
    public virtual int GetPizzaType() 
    {
        return 0; // Default pizza type
    }

    public virtual string GetPrefabAssetPath()
    {
        return "AndAssets/Prefabs/CrudePizzaPrefab";
    }

    public virtual float GetPizzaDeliveryTime()
    {
        return 200f;
    }

    public virtual int GetScoreUponDelivery()
    {
        return 10;
    }
    
}

// Pizza Sub Classes

public class CheesePizza : CrudePizza
{
    public override int GetPizzaType()
    {
        return 1; // Cheese pizza type
    }

    public override string GetPrefabAssetPath()
    {
        return "AndAssets/Prefabs/CheesePizzaPrefab";
    }

    public virtual float GetPizzaDeliveryTime()
    {
        return 60f;
    }

    public override int GetScoreUponDelivery()
    {
        return 10;
    }
}

public class OnionPizza : CrudePizza
{
    public override int GetPizzaType()
    {
        return 2; // Onion pizza type
    }

    public override string GetPrefabAssetPath()
    {
        return "AndAssets/Prefabs/OnionPizzaPrefab";
    }

    public virtual float GetPizzaDeliveryTime()
    {
        return 30f;
    }

    public override int GetScoreUponDelivery()
    {
        return 20;
    }
}

public class MushroomPizza : CrudePizza
{
    public override int GetPizzaType()
    {
        return 3; // Mushroom pizza type
    }

    public override string GetPrefabAssetPath()
    {
        return "AndAssets/Prefabs/MushroomPizzaPrefab";
    }

    public virtual float GetPizzaDeliveryTime()
    {
        return 15f;
    }

    public override int GetScoreUponDelivery()
    {
        return 30;
    }
}
//*/
