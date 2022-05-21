using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public MeshFilter mesh;

    void Awake()
    {
        this.gameObject.tag = "Item";
    }

    void PickUp() {

    }
    
    void Throw() {

    }
}