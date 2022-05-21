using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PROPERTY OF SIMON: DO NOT EDIT
public class PlayerController : MonoBehaviour
{

    private CharacterController _controller;

    private Camera mainCam;

    public float speed;
    [SerializeField] private float playerHorizontal;
    [SerializeField] private float playerVertical;

    public float sensitivity;
    [SerializeField] private float playerLookHorizontal;
    [SerializeField] private float playerLookVertical;
    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        mainCam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void updateMovement()
    {
        playerVertical = Input.GetAxis("Vertical");
        playerHorizontal = Input.GetAxis("Horizontal");
        Vector3 target = (mainCam.transform.forward * speed * playerVertical * Time.deltaTime) +
                                     (mainCam.transform.right * speed * playerHorizontal * Time.deltaTime);
        _controller.Move(new Vector3(target.x, 0.0f, target.z));
    }

    void updateLook()
    {
        float verticle = Input.GetAxis("Mouse Y");
        float horitnzal = Input.GetAxis("Mouse X");

        playerLookHorizontal += horitnzal * sensitivity;
        playerLookVertical -= verticle * sensitivity;

        playerLookVertical = Mathf.Clamp(playerLookVertical, -90, 90);

        mainCam.transform.eulerAngles = new Vector3(playerLookVertical, playerLookHorizontal, 0.0f);


    }
    
    // Update is called once per frame
    void Update()
    {
        updateMovement();
        updateLook();
        
    }
}
