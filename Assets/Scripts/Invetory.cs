using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory : MonoBehaviour
{
    public float maxSize;
    [SerializeField] private List<Item> invetory;
    // Start is called before thLeftControle first frame update
    private int equippedSlot = 0; 
    // Start is called before the first frame update
    void Start()
    {
        invetory = new List<Item>();
    }

    public void addItem(Item owo)
    {
        if (invetory.Count < maxSize)
        {
            invetory.Add(owo);
            Debug.Log("Adding: "+ owo.name);
        }
    }

    public void removeItem(string name)
    {
        foreach (Item obj in invetory)
        {
            if (obj.name.Equals(name))
            {
                invetory.Remove(obj);
            }
        }
    }

    public void removeAll()
    {
        invetory.Clear();
    }

    public bool hasItem(Item name)
    {
        foreach (Item itm in invetory)
        {
            if (itm.name == name.name)
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
