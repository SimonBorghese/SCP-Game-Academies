using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorButton : Interactable
{
    public override void yeah()
    {
        Debug.Log("Never Mind");
    }

    private void Start()
    {
        Interactable inter = this.GetComponent<Interactable>();
        inter.yeah();
    }
}
