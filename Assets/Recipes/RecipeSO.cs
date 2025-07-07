using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipes", menuName = "ScriptableObjects/Recipes")]
public class RecipeSO : ScriptableObject
{
    public Recipe[] Recipes;
}
