using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float JumpPower = 7;

    public Rigidbody rb;

    public Camera camera;
    public Transform cameraPivot;

    public float MouseSensitivity = 3;
    float xRotation = 0f;


    public Vector3 cameraOffset = new Vector3(0.5f, 0f, -3);
    public Vector3 aimCameraOffset = new Vector3(1.5f, 0f, -1.5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera.transform.localRotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraMove();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transform.forward/right are relative to the direction my body is facing
        Vector3 move = transform.forward * z + transform.right * x;
        //I reduce my total movement to 1 and then multiply it by my speed
        move = move * speed;

        //If I hit jump and am on the ground, I jump
        if (JumpPower > 0 && Input.GetKeyDown(KeyCode.Space))
            move.y = JumpPower;
        else  //Otherwise, my Y velocity is whatever it was last frame
            move.y = rb.linearVelocity.y;

        //Plug my calculated velocity into the rigidbody
        rb.linearVelocity = move;
    }

    void CameraMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        transform.Rotate(0, mouseX, 0);

        xRotation += mouseY * MouseSensitivity / 2 * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -30, 30);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
