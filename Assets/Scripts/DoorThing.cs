using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorThing : MonoBehaviour
{
    private bool open;

    public Animator anim;

    // Start is called before the first frame update
    void Start() {

    }

    void Awake() {
        open = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OpenDoor() {
        if(open)return;
        open = true;

        
    }
}
