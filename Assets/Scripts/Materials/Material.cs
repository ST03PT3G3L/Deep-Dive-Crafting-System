using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "ScriptableObjects/CreateMaterial", order = 1)]
public class CraftMaterial : ScriptableObject
{
    static int nextId = 1;
    public int id;
    public string materialName;
    public string materialDescription;

    public CraftMaterial()
    {
        id = nextId;
        nextId++;
    }
}