using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentRemover : MonoBehaviour
{
    public Item requiredItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) &&
            other.gameObject.GetComponent<Invetory>().hasItem(requiredItem))
        {
            Destroy(this.gameObject);
        }
    }
}
