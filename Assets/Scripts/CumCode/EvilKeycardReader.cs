using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilKeycardReader : MonoBehaviour
{
    private GameObject plr;

    public Item wow;
    public Item screwdriver;
    
    
    public ParticleSystem spark;

    public AudioSource openNormal;

    public AudioSource sparks;
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
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player") && (plr.GetComponent<Invetory>().hasItem(wow) || plr.GetComponent<Invetory>().hasItem(screwdriver) ))
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

            if (!plr.GetComponent<Invetory>().hasItem(wow))
            {
                sparks.Play();
                spark.Play();
                GameObject[] scps = GameObject.FindGameObjectsWithTag("SCP");
                foreach (GameObject objSCP in scps)
                {
                    objSCP.GetComponent<BasicNodedAI>().setSoundTarget(this.gameObject);
                }
            }
            openNormal.Play();
            obj.GetComponent<DoorThing>().ChangeState();
        }
    }
}