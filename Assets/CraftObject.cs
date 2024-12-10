using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftObject : MonoBehaviour
{
    public Recipe recipeData;

    public void CraftItem()
    {
        CraftingController.Instance.craftEvent.Invoke(recipeData.id);
    }
}
