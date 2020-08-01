using System.Security.Permissions;
using UnityEngine;

public class s_Camera : MonoBehaviour
{
    public Camera cam;                  //本体
    public Transform target;            //物体的Transform
    public Vector3 offset;              //摄像机与物体之间的位移
    public Vector3 diffVector;          //
    public Vector2 rotate;              //
    public float rotateSpeed = 5.0f;    //摄像机旋转速度
    public float radius = 5;            //环绕半径
    public float maxAngle = 60;         //最大仰角
    public float minAngle = -45;        //最大俯角 
    public bool isAiming = false;       //是否在瞄准
    public float axisX = 0f;            //鼠标输入轴X
    public float axisY = 0f;            //鼠标输入轴Y
    public float maxFOV = 40;           //最大缩放视角
    public float minFOV = 20;           //最小缩放视角
    public float aimVelocity = 0f;

    public s_Shoot shootScript;

    public CursorLockMode lockMode;

    void Start()
    {
        cam = this.GetComponent<Camera>();
        diffVector = -Vector3.forward;
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        axisX = Input.GetAxisRaw("Mouse X"); 
        axisY = Input.GetAxisRaw("Mouse Y");

        rotate.x += axisX * rotateSpeed;
        rotate.y += axisY * rotateSpeed;

        if (rotate.x >= 360 || rotate.x <= -360)
        {
            rotate.x = 0;
        }

        if (rotate.y < minAngle)
        {
            rotate.y = minAngle;
        }
        else if (rotate.y > maxAngle)
        {
            rotate.y = maxAngle;
        }

        SetAim();
        SetPosition();
        GetAimPoint();
        Debug.DrawLine(target.position, cam.transform.position, Color.blue);
    }

    void SetPosition()
    {

        Vector3 temp = -Vector3.forward;
        temp = (Quaternion.Euler(-rotate.y, rotate.x, 0) * temp).normalized * radius;
        
        
        diffVector = temp;

        this.transform.position = target.position + diffVector;
        this.transform.LookAt(target);
        this.transform.position += Quaternion.Euler(-rotate.y, rotate.x, 0) * offset;

        CollisionAvoidance();

        if (isAiming)
            cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, minFOV, ref aimVelocity, 0.1f);
        else cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, maxFOV, ref aimVelocity, 0.1f);
        //Debug.Log(Vector3.Distance(cam.transform.position, target.position));
    }

    void SetAim()
    {
        if (Input.GetKey(KeyCode.Mouse1))
            isAiming = true;
        else isAiming = false;
    }

    void CollisionAvoidance()
    {
        Ray ray = new Ray(target.position, cam.transform.position - target.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, (cam.transform.position - target.position).magnitude))
        {
            if (hit.collider.gameObject.tag == "Player") return;
            Debug.Log("Camera Collied");
            Vector3 v = Vector3.zero;
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, (hit.point - (cam.transform.position - target.position).normalized * 1f), ref v, 0f);
        }
    }

    public Vector3 GetAimPoint() //应该改成从枪口判断瞄准点
    {
        Vector3 pos = Vector3.zero;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f) && Vector3.Dot(cam.transform.forward, (hit.point - target.position)) > 0f)
        {
            pos = hit.point;
        }
        else
        {
            pos = cam.transform.forward * 100000;
        }
        Debug.DrawRay(transform.position, pos - transform.position);
        return pos;
    }

    public Vector3 GetRealHitPoint()
    {
        Vector3 pos = Vector3.zero;
        Vector3 aimPoint = GetAimPoint();
        Ray ray = new Ray(shootScript.ShootPoint.position, aimPoint - shootScript.ShootPoint.position);
        Debug.DrawRay(cam.transform.position, ray.direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, (aimPoint - shootScript.ShootPoint.position).magnitude) && hit.collider.gameObject.tag != "Bullet")
        {
            pos = hit.point;
        }
        else
        {
            pos = aimPoint;
        }
        return pos;
    }
}
