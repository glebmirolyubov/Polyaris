using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialInstanceManager : MonoBehaviour
{
    public Material instancedMaterial;

    void Start()
    {
        instancedMaterial = GetComponent<MeshRenderer>().material;
    }
}
