using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class s_Move : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpForce = 10.0f;
    public float rotateSpeed = 5.0f;
    public Vector3 direction;
    public float axisVertical;
    public float axisHorizontal;
    private bool isJumping = false;

    public Transform cam;
    private Rigidbody rigidBody;
    

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        float axisVertical = Input.GetAxisRaw("Vertical");
        float axisHorizontal = Input.GetAxisRaw("Horizontal");
        if (axisHorizontal != 0.0 || axisVertical != 0.0 || Input.GetKeyDown(KeyCode.Space))
        {
            direction.Set(axisHorizontal, 0, axisVertical);
            direction.Normalize();
            Turn();
            Jump();
            Move();
        }

    }

    void Turn()
    {
        Vector3 camForward = new Vector3(cam.forward.x, 0, cam.forward.z).normalized;
        float angle = Vector3.SignedAngle(Vector3.forward, camForward, Vector3.up);
        direction = Quaternion.Euler(0, angle, 0) * direction;
        Debug.DrawRay(transform.position, direction, Color.green);
        Debug.DrawRay(cam.position, camForward, Color.green);

    }

    void Move()
    {
        Vector3 lastVelocity = rigidBody.velocity;
        if (!isJumping)
        {
            lastVelocity.Set(direction.x * moveSpeed, lastVelocity.y, direction.z * moveSpeed);
        }
        else
        {
            lastVelocity.Set(direction.x * moveSpeed, direction.y * moveSpeed, direction.z * moveSpeed);
        }

        rigidBody.velocity = lastVelocity;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction.y = jumpForce;
            isJumping = true;
        }
        else
        {
            isJumping = false;           
        }
    }
}
