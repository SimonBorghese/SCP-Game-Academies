using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilKeycardReader : MonoBehaviour
{
    public int requiredLevel;

    private Invetory player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject plr = GameObject.FindWithTag("Player");
        if (!plr.TryGetComponent( out player))
        {
            Debug.Log("For some fucking reason the player doesn't have an invetory, give it one :)");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player") && player.hasItem("Keycard"))
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