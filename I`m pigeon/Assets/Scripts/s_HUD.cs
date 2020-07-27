using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_HUD : MonoBehaviour
{
    public s_Shoot shootScript;
    public s_Camera camScript;
    public s_FPSCam fpsCamScript;
    public Text magHUD;
    public Image realHitPointHUD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        showWeaponStatus();
        showRealHitPoint();
    }

    void showWeaponStatus()
    {
        if (shootScript.isReloading)
        {
            magHUD.text = "Reloading...  " + shootScript.ptrReloadTime;
        }
        else
        {
            magHUD.text = shootScript.ptrAmmo + "/" + shootScript.maxAmmo + "\n" + shootScript.backupAmmo + " Left";
        }

    }

    void showRealHitPoint()
    {
        Vector3 p = camScript.GetRealHitPoint();
        Vector3 p2 = camScript.cam.WorldToScreenPoint(p);
        p2.z = 10;
        Debug.Log(p2);
        realHitPointHUD.transform.position = p2;
    }
}
