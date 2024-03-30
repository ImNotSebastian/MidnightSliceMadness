/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Monster Factory
This class deals with spawining monsters
It inherits from MonoBehaviour
This class is part of a Factory pattern
*/

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
