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
}
//*/
