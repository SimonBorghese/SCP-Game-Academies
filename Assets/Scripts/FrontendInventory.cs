using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontendInventory : MonoBehaviour
{
    public GameObject slot;

    private Invetory invetory;
    private List<GameObject> slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<GameObject>();
    }

    void Awake() {
        invetory = (Invetory)this.gameObject.GetComponent(typeof(Invetory));

        for(int i=0; i<invetory.maxSize; i++) {
            GameObject placement = Instantiate(slot);
            placement.transform.parent = this.gameObject.transform;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
