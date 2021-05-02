using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    //camera looking stuff
    public GameObject cam;
    public GameObject cameraHolder;
    public float sensitivityX = 10f;
    public float sensitivityY = 10f;
    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    float rotationX = 0f;
    float rotationY = 0f;

    Quaternion originalRotation;

    public float playerMoveForce;
    public int playerJumpForce;
    private bool canJump;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localRotation;

        rigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking if the player can jump
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, Vector3.down, out hit, 1.1f))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        //camera Movement
        //Gets rotational input from the mouse
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;

        //Clamp the rotation average to be within a specific value range
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        rotationX = ClampAngle(rotationX, minimumX, maximumX);

        //Get the rotation you will be at next as a Quaternion
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);

        //Rotate
        cameraHolder.transform.rotation = originalRotation * xQuaternion * yQuaternion;
        player.transform.rotation = xQuaternion;

        //movement
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(player.transform.forward * playerMoveForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(-player.transform.forward * playerMoveForce);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(-player.transform.right * playerMoveForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(player.transform.right * playerMoveForce);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rigidbody.AddForce(0, playerJumpForce, 0);
        }

    }

    float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }
}
