using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/CreateRecipe", order = 1)]
public class Recipe : ScriptableObject
{
    static int nextId = 1;
    public int id;
    public string recipeName;
    public string recipeDescription;
    public GameObject createdItem;

    [SerializeField]
    public RecipeMaterial[] materials;

    Recipe()
    {
        id = nextId;
        nextId++;
    }
}

[Serializable]
public class MaterialList
{
    public List<RecipeMaterial> materialList;
}