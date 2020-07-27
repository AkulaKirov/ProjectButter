using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootPoint;
    public s_Camera camScript;
    public s_FPSCam fpsCamScript;
    public bool isShooting = false;
    public bool isAmmoLeft = false;
    public bool isReloading = false;

    public float fireRate = 0.3f;
    private float fireCoolDown = 0f;

    public float reloadTime = 3f;
    public float ptrReloadTime = 0f;

    public int backupAmmo = 180;
    public int maxAmmo = 30;
    public int ptrAmmo = 0;

    void Start()
    {
        
    }

    void Update()
    {
        CoolDown();
        Reload();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isShooting = true;
            Shoot();
        }
        else
        {
            isShooting = false; 
        }
    }

    void Shoot()
    {
        if (fireCoolDown >= 0f)
        {
            Debug.Log("Still Cooling Down,eta:" + fireCoolDown);
        }
        else if (isAmmoLeft == false || isReloading == true)
        {
            Debug.Log("No Ammo Left or Reloading");
        }
        else
        {
            Vector3 point = camScript.GetAimPoint();
            Vector3 dir = (point - ShootPoint.position).normalized;
            Debug.DrawRay(ShootPoint.position, dir, Color.red);
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = ShootPoint.transform.position;
            bullet.GetComponent<Rigidbody>().velocity = (dir * 1000);

            Debug.Log("Bullet Shooted");
            fireCoolDown = fireRate;
            ptrAmmo--;
            if (ptrAmmo == 0)
            {
                isAmmoLeft = false;
            }
        }

    }

    void Reload()
    {
        if (Input.GetKey(KeyCode.R))
        {
            isReloading = true;
            ptrReloadTime = reloadTime;
        }
        if (isReloading == true && ptrReloadTime <= 0f)
        {
            Debug.Log("Reloading");
            int delta = maxAmmo - ptrAmmo;
            if (delta > backupAmmo)
            {
                ptrAmmo += backupAmmo;
                backupAmmo = 0;
            }
            else
            {
                ptrAmmo += delta;
                backupAmmo -= delta;
            }

            isReloading = false;
            isAmmoLeft = true;
        }
        else if (ptrReloadTime > 0f)
        {
            ptrReloadTime -= Time.deltaTime;
        }
    }

    void CoolDown()
    {
        if (fireCoolDown >= 0f)
        {
            fireCoolDown -= Time.deltaTime;
        }
    }
}
