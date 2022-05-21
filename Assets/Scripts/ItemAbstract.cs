using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    protected bool onGround;
    protected float defaultY;

    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        this.gameObject.tag = "Item";
    }

    // Update is called once per frame
    void Update()
    {
        if(onGround) {
            defaultY = this.gameObject.transform.position.y - Mathf.Sin(elapsed * Mathf.PI);
            elapsed += Time.deltaTime;
            this.gameObject.transform.Rotate(elapsed, 0.0f, 0.0f);
            this.gameObject.transform.position = new Vector3(
                this.gameObject.transform.position.x,
                defaultY + Mathf.Sin(elapsed * Mathf.PI),
                this.gameObject.transform.position.z
            );
        }else {
            elapsed = 0;
            defaultY = this.gameObject.transform.position.y;
        }
    }
}