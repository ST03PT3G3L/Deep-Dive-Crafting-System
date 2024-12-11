using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    public List<RecipeMaterial> recipeMaterials = new List<RecipeMaterial>();

    public UnityEvent updateInventoryEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            updateInventoryEvent.Invoke();
        }
    }
}