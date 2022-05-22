using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilButtonCode : MonoBehaviour
{
    
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] founds = GameObject.FindGameObjectsWithTag("Door");
            GameObject obj = founds[0];
            float furtherst = Vector3.Distance(this.transform.position, founds[0].transform.position);
            foreach (GameObject tester in founds)
            {
                if (Vector3.Distance(transform.position, tester.transform.position) <= furtherst)
                {
                    obj = tester;
                    furtherst = Vector3.Distance(transform.position, tester.transform.position);
                }
            }

            GetComponent<AudioSource>().Play();
            obj.GetComponent<DoorThing>().ChangeState();
        }
    }
}


