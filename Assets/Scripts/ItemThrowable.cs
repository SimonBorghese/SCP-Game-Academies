using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThrowable : MonoBehaviour
{
    public Item targetItem;

    public BasicNodedAI[] SCPs;

    private bool alreadyDied = false;

    public float height = 2.0f;

    private Rigidbody body;
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

        Rigidbody body2;
        if (TryGetComponent(out body2))
        {
            body = body2;
            body.angularVelocity = (Camera.main.transform.forward * height);
        }


    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!alreadyDied && collision.gameObject.isStatic)
        {
            foreach (BasicNodedAI ai in SCPs)
            {
                ai.setSoundTarget(this.gameObject);
            }

            alreadyDied = true;
        }
    }
}
