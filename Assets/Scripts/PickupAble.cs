using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{
    public GameObject player;

    public Item targetItem;

    public AudioSource pickupOwO;

    private bool markedForDeath = false;
    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player.GetComponent<Invetory>().addItem(targetItem);
                pickupOwO.Play();
                markedForDeath = true; 
                //Destroy(this.gameObject);
            }
        }
    }
}
