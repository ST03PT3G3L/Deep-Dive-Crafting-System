using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExampleInventoryScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI inventoryItem;

    [SerializeField]
    InventoryController inventoryController;

    [SerializeField]
    GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        inventoryController.updateInventoryEvent.AddListener(UpdateInventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventory()
    {
        foreach(Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(RecipeMaterial c in inventoryController.recipeMaterials)
        {
            if (c.materialCount > 0)
            {
                inventoryItem.text = $"{c.material.materialName} x{c.materialCount}";
                var ob = Instantiate(inventoryItem.gameObject, content.transform);
            }
            else
            {
                inventoryController.recipeMaterials.Remove(c);
            }
        }
    }
}
