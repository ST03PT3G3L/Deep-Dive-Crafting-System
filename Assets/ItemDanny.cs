using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDanny : ItemBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCraft()
    {
        Debug.Log("Danny item has been crafted");
    }
}
