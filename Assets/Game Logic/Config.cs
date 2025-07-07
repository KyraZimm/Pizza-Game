using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
public class Config : ScriptableObject
{
    [Header("Player Settings")]
    public GameObject PlayerPrefab;
    public Vector2 SpawnPos;
    public Vector2 HorizontalBounds;
    public Vector2 VerticalBounds;

    [Header("Recipe Settings")]
    public RecipeSO ActiveRecipes;

    [Header("Customer Settings")]
    public GameObject CustomerPrefab;
    public Color[] PossibleSpriteColors; //will be replaced with sprites once I do some basic artwork
    public float CustomerSpawnIntervals;
    public float SpaceBetweenCustomersAtCounter;

    private const string INSTANCE_FILE_PATH = "Assets/Config";
#if UNITY_EDITOR
    public static string[] GetAllRecipeIDs_EditorOnly() {
        Config config = AssetDatabase.LoadAssetAtPath<Config>(INSTANCE_FILE_PATH);

        List<string> recipeIDs = new List<string>();
        foreach (Recipe recipe in config.ActiveRecipes.Recipes) {
            recipeIDs.Add(recipe.ID);
        }

        //alphabetize
        recipeIDs.Sort();

        return recipeIDs.ToArray();
    }
#endif
}