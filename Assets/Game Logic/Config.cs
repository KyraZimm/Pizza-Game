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
}
