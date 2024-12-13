using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;

    [SerializeField]
    public List<RecipeMaterial> recipeMaterials = new List<RecipeMaterial>();

    public UnityEvent updateInventoryEvent;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        updateInventoryEvent.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            updateInventoryEvent.Invoke();
        }
    }
}
