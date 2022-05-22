using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundItem : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryUI;
    public Item item;

    private Invetory invetory;
    
    private float elapsed;
    private bool detect;
    private bool pickedUp;

    private Vector3 tempPos;
    
    // Start is called before the first frame update
    void Start()
    {
        invetory = inventoryUI.transform.GetComponent<Invetory>();
    }
    
    //Update Fixed
    void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            if(Input.GetMouseButtonDown(0))
            {
                tempPos = this.gameObject.transform.position;
                detect = true;
            }

            if(detect)
            {
                if(elapsed >= 1/5 && !pickedUp)
                {
                    PickUpObject();
                    return;
                }else if (pickedUp)
                {
                    return;
                }
                
                this.gameObject.transform.position = Vector3.Lerp(tempPos, player.transform.position, Mathf.Clamp(elapsed * 5, 0, 1));
                elapsed += Time.deltaTime;
            }
        }
    }

    public void PickUpObject()
    {
        invetory.addItem(item);
        pickedUp = true;
        
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}