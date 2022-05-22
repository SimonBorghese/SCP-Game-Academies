using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilKeycardReader : MonoBehaviour
{
    public int requiredLevel;

    private GameObject plr;

    public Item wow;
    // Start is called before the first frame update
    void Start()
    {
         plr = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(plr.GetComponent<Invetory>().hasItem(wow));
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player") && plr.GetComponent<Invetory>().hasItem(wow))
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