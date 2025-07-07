using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string ID;
    public Ingredient[] Ingredients;
}

[System.Serializable]
public class Ingredient {
    public string ID;
}