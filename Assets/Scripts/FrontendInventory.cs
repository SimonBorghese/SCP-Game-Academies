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
        slots = new List<GameObject>();
        invetory = this.gameObject.GetComponent<Invetory>();

        for(int i=0; i<invetory.maxSize; i++) {
            GameObject placement = Instantiate(slot);
            placement.transform.SetParent(this.gameObject.transform);
            slots.Add(placement);
        }

        createSlots(open);
    }

    void Awake() {
        open = false;
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

    public Invetory getBackend() {
        return invetory;
    }
}