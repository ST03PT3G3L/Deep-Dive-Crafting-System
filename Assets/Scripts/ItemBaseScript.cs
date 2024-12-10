using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField]
    public string itemName = "DebugName";
    [SerializeField]
    public string description = "DebugDescription";
    virtual public void OnCraft()
    {
        Debug.Log($"Item {description} is succesfully crafted!");
    }

    virtual public void OnUse()
    {
        Debug.Log($"Item {itemName} has been used!");
    }
}
