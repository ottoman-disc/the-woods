using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class TileMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        MeshFilter mf = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
