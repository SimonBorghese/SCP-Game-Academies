using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontendInventory : MonoBehaviour
{
    public GameObject slot;

    private Invetory invetory;
    private List<GameObject> slots;

    private bool open;

    // Start is called before the first frame update
    void Start() {
        open = false;
    }

    void Awake() {
        slots = new List<GameObject>();
        invetory = (Invetory)this.gameObject.GetComponent(typeof(Invetory));

        for(int i=0; i<invetory.maxSize; i++) {
            GameObject placement = Instantiate(slot);
            placement.transform.SetParent(this.gameObject.transform);
            slots.Add(placement);
        }
    }

    void createSlots(bool createIt) {
        for(int i=0; i<slots.Count; i++) {
            slots[i].SetActive(createIt);
        }
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            open = !open;
            createSlots(open);
        }
    }
}