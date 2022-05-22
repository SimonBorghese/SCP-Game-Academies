using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThrowable : MonoBehaviour
{
    public Item targetItem;

    public BasicNodedAI[] SCPs;

    private bool alreadyDied = false;

    public float height = 250.0f;

    private Rigidbody body;

    public AudioSource hitSound;
    void Start()
    {
        GameObject[] foundObjs = GameObject.FindGameObjectsWithTag("SCP");
        SCPs = new BasicNodedAI[foundObjs.Length];
        int currentPos = 0;
        foreach (GameObject obj in foundObjs)
        {
            BasicNodedAI outAi;
            if (obj.TryGetComponent(out outAi))
            {
                SCPs[currentPos++] = outAi;
            }
        }

        body = GetComponent<Rigidbody>();
        body.velocity = (Camera.main.transform.forward) * 25;
        //body.AddForce(Camera.main.transform.forward * height, ForceMode.Acceleration);
        


    }

    private void Update()
    {
        //body.AddForce((Camera.main.transform.forward * (height * Time.deltaTime)), ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!alreadyDied && collision.gameObject.isStatic)
        {
            foreach (BasicNodedAI ai in SCPs)
            {
                ai.setSoundTarget(this.gameObject);
            }
            hitSound.Play();
            alreadyDied = true;
        }
    }
}
