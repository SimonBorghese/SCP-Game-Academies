using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    //Update Fixed
    private void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
