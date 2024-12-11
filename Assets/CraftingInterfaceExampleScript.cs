using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CraftingInterfaceExampleScript : MonoBehaviour
{
    [SerializeField]
    CraftingController craftingController;

    [SerializeField]
    InventoryController inventoryController;

    [SerializeField]
    CraftObject craftingUIObject;

    [SerializeField]
    GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        inventoryController.updateInventoryEvent.AddListener(UpdateCraftInterface);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCraftInterface()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Recipe recipe in craftingController.recipes)
        {
            craftingUIObject.recipeData = recipe;
            craftingUIObject.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = recipe.name;
            craftingUIObject.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = recipe.recipeDescription;
            craftingUIObject.transform.Find("Recipe").GetComponent<TextMeshProUGUI>().text = "";
            foreach (RecipeMaterial r in recipe.materials)
            {
                int inventoryCount;

                RecipeMaterial mat = inventoryController.recipeMaterials.FirstOrDefault(rm => rm.material == r.material);
                if (mat == null)
                {
                    inventoryCount = 0;
                }
                else
                {
                    inventoryCount = mat.materialCount;
                }

                craftingUIObject.transform.Find("Recipe").GetComponent<TextMeshProUGUI>().text += $"{r.material.name} {inventoryCount}/{r.materialCount}<br>";
            }
            GameObject c = Instantiate(craftingUIObject.gameObject, content.transform);
        }
    }
}
