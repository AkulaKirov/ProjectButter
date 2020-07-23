using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootPoint;
    public s_Camera camScript;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 point = camScript.GetAimPoint();
        Vector3 dir = (point - ShootPoint.position).normalized;
        Debug.DrawRay(ShootPoint.position, dir, Color.red);
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = ShootPoint.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = (dir * 100);

        Debug.Log("Bullet Shooted");

    }
}
