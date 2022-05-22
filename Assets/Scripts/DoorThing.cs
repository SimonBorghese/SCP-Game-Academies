using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorThing : MonoBehaviour
{
    private bool open;

    public Animator anim;
    public bool locked;

    public AudioSource openSound;
    public AudioSource closeSound;

    // Start is called before the first frame update
    void Start() {

    }

    void Awake() {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (locked && open)
            CloseDoor();
    }

    public void OpenDoor() {
        if(open || locked)
            return;
        
        open = true;
        openSound.Play();
        anim.SetBool("Open Door", open);
        anim.SetTrigger("SetDoorStateTo");
    }
    
    public void CloseDoor() {
        if(!open)
            return;
        
        open = false;
        closeSound.Play();
        anim.SetBool("Open Door", open);
        anim.SetTrigger("SetDoorStateTo");
    }

    public void ChangeState()
    {
        if (open)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
}
