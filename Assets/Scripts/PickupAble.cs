using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{
    public GameObject player;
    private GameObject inventory;

    public Item targetItem;

    public AudioSource pickupOwO;

    private bool pickedUp = false;

    private bool markedForDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Canvas/Inventory");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (markedForDeath)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E) && !pickedUp)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                inventory.GetComponent<Invetory>().addItem(targetItem);
                pickupOwO.Play();
                markedForDeath = true;
                pickedUp = true;
                //Destroy(this.gameObject);
            }
        }
    }
}
