using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarybutton : MonoBehaviour
{
    
    [SerializeField] VictoryUI ui;
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
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player"))
        {
            ui.showVictory();
        }
    }
}
