using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory : MonoBehaviour
{
    public float maxSize;
    private List<Item> invetory;

    private FrontendInventory iv;
    // Start is called before thLeftControle first frame update
    private int equippedSlot = 0; 
    // Start is called before the first frame update
    void Start()
    {
        invetory = new List<Item>();
    }

    void addItem(Item owo)
    {
        if (invetory.Count < maxSize)
        {
            invetory.Add(owo);
        }
    }

    void removeItem(string name)
    {
        foreach (Item obj in invetory)
        {
            if (obj.name.Equals(name))
            {
                invetory.Remove(obj);
            }
        }
    }

    void removeAll()
    {
        invetory.Clear();
    }

    public bool hasItem(string name)
    {
        foreach (Item item in invetory)
        {
            if (item.name.Equals(name))
            {
                return true;
            }
        }

        return false;
    }
    
    public bool useItem(string name)
    {
        foreach (Item item in invetory)
        {
            if (item.name.Equals(name))
            {
                invetory.Remove(item);
                return true;
            }
        }

        return false;
    }

    public Item equippedItem()
    {
        return invetory[equippedSlot];
    }

    public Item getItemInList(int index)
    {
        return invetory[index];
    }

    void Update()
    {
        
    }
}
