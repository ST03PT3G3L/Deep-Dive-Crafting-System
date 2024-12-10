using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TestItem : ItemBase
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnUse();
        }
    }

    public override void OnCraft()
    {
        Debug.Log("Help Me!");
        StartCoroutine("crafted");
    }

    IEnumerator crafted()
    {
        yield return new WaitForSeconds(.5f);
        transform.localScale = new Vector3(5, 5, 5);
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(1, 1, 1);
    } 
}
