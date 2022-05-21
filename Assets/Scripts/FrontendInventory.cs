using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontendInventory : MonoBehaviour
{
    private Invetory invetory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        invetory = (Invetory)this.gameObject.GetComponent(typeof(Invetory));
    }

    //Panel makeSlot() {
    //    return null;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
