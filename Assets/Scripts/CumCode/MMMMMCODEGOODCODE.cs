using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMMMMCODEGOODCODE : MonoBehaviour
{
    public Invetory target;

    public Item owo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            target.addItem(owo);
        }
    }
}
