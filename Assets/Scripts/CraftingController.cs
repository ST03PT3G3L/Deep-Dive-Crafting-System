using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CraftingController : MonoBehaviour
{
    [SerializeField]
    InventoryController inventoryController;

    [SerializeField]
    public List<Recipe> recipes = new List<Recipe>();

    public UnityEvent<int> craftEvent;

    int i = -15;

    public static CraftingController Instance;

    private void Start()
    {
        Instance = this;

        craftEvent.AddListener(Craft);
    }

    private void Update()
    {
    }

    public void Craft(int id)
    {
        Recipe recipe = recipes.Find(x => x.id == id);

        if (recipe != null)
        {
            bool craftable = true;

            foreach(RecipeMaterial r in recipe.materials)
            {
                RecipeMaterial invMat = inventoryController.recipeMaterials.FirstOrDefault(x => x.material == r.material);
                if(invMat == null)
                { return; }

                if(invMat.materialCount < r.materialCount)
                {
                    craftable = false;
                }
            }

            if(craftable)
            {
                foreach (RecipeMaterial r in recipe.materials)
                {
                    RecipeMaterial invMat = inventoryController.recipeMaterials.Find(x => x.material == r.material);
                    invMat.materialCount -= r.materialCount;
                }

                GameObject craftedItem = Instantiate(recipe.createdItem.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
                craftedItem.GetComponent<ItemBase>().OnCraft();
                inventoryController.updateInventoryEvent.Invoke();
            }

        }
    }
}
