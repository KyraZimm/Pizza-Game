using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
public class Config : ScriptableObject
{
    [Header("Player Settings")]
    public GameObject PlayerPrefab;
    public Vector2 SpawnPos;
    public Vector2 HorizontalBounds;
    public Vector2 VerticalBounds;

    [Header("Recipe Settings")]
    public Recipe[] ActiveRecipes;

    [Header("Customer Settings")]
    public GameObject CustomerPrefab;
    public Color[] PossibleSpriteColors; //will be replaced with sprites once I do some basic artwork
    public float CustomerSpawnIntervals;
    public float SpaceBetweenCustomersAtCounter;
}
