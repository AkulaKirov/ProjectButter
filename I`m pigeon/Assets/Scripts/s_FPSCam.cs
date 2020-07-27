using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_FPSCam : MonoBehaviour
{
    public Camera mainCam;
    public Camera fpsCam;
    public s_Shoot shootScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.forward, Color.red);
        this.transform.rotation = mainCam.transform.rotation;
    }

    public Vector3 GetAimPoint() //应该改成从枪口判断瞄准点
    {
        Vector3 pos = Vector3.zero;
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            pos = hit.point;
        }
        else
        {
            pos = fpsCam.transform.forward * 100000;
        }
        Debug.DrawRay(transform.position, pos - transform.position);
        return pos;
    }

    public Vector3 GetRealHitPoint()
    {
        Vector3 pos = Vector3.zero;
        Vector3 aimPoint = GetAimPoint();
        Ray ray = new Ray(shootScript.ShootPoint.position, aimPoint - shootScript.ShootPoint.position);
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
