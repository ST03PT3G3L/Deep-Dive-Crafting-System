using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TestItem : ItemBase
{
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnUse();
        }
    }
    public override void OnUse()
    {
        anim.Play("RotateAnimation");
    }

    public override void OnCraft()
    {
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
