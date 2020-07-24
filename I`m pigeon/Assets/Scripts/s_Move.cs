
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
    public s_Camera camScript;
    public s_Shoot shootScript;
    

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        float axisVertical = Input.GetAxisRaw("Vertical");
        float axisHorizontal = Input.GetAxisRaw("Horizontal");

        if (axisHorizontal != 0.0 || axisVertical != 0.0 || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
        {
            //if (axisHorizontal != 0.0 || axisVertical != 0.0)
            {
                direction.Set(axisHorizontal, 0, axisVertical);
            }

            direction.Normalize();
            Turn();
            Jump();
            Move();
        }

    }



    void Turn()
    {
        Vector3 camForward = new Vector3(cam.forward.x, 0, cam.forward.z).normalized;
        //Debug.Log(direction);
        float angle = Vector3.SignedAngle(Vector3.forward, camForward, Vector3.up);
        direction = Quaternion.Euler(0, angle, 0) * direction;

        //这里有一个诡异的效果 Slerp的时间不够可能会导致方向不完全对齐
        //找时间修复

        if (camScript.isAiming == true || Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("angle:" + angle);
            Quaternion q = Quaternion.Euler(0, angle, 0);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, q, 0.1f);
            return;
        }

        float angle2 = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
        //Debug.Log("angle2:" + angle2);
        Quaternion q2 = Quaternion.Euler(0, angle2, 0);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, q2, 0.1f);

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
