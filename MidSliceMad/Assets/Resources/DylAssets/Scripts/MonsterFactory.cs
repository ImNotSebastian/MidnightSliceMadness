using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public enum MonsterType
    {
        Ghost,
        // Add more types as needed
    }

    public static Monster CreateMonster(MonsterType type)
    {
        switch (type)
        {
            case MonsterType.Ghost:
                return new GameObject("Ghost").AddComponent<Ghost>();
            // Add cases for additional monsters
            default:
                return null;
        }
    }
}
