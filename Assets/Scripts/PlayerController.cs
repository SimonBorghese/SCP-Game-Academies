using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
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

    public float jumpHeight;
    [SerializeField] private float fallLevel;

    [SerializeField] private float gravity;

    private float initHeight;

    public float crouchDivider;


    public GameObject itemThrow;
    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        mainCam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        gravity = Physics.gravity.y;
        initHeight = _controller.height;
    }

    void updateMovement()
    {
        playerVertical = Input.GetAxis("Vertical");
        playerHorizontal = Input.GetAxis("Horizontal");
        Vector3 target = (mainCam.transform.forward * speed * playerVertical * Time.deltaTime) +
                                     (mainCam.transform.right * speed * playerHorizontal * Time.deltaTime);
        _controller.Move(new Vector3(target.x, fallLevel * Time.deltaTime, target.z));
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

    void updateJump()
    {
        if (fallLevel < gravity)
        {
            fallLevel = gravity;
        }

        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            fallLevel = -(gravity * 2) * jumpHeight;
        }

        fallLevel += gravity * Time.deltaTime;
    }

    void updateCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_controller.height != initHeight / crouchDivider)
            {
                _controller.height = initHeight / crouchDivider;
            }
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            _controller.Move(new Vector3(0, initHeight / crouchDivider, 0));
            if (_controller.height != initHeight)
            {
                _controller.height = initHeight;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateMovement();
        updateLook();
        updateJump();
        updateCrouch();

        if ( itemThrow != null && Input.GetButtonDown("Fire1"))
        {
            Instantiate(itemThrow, transform.position + Vector3.up + (mainCam.transform.forward * 2), new Quaternion());
        }
    }

    public void throwItem(GameObject item)
    {
        itemThrow = item;
    }
}
