using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_CamControl : MonoBehaviour
{
    public Camera mainCam;
    public Camera fpsCam;

    public bool isFPS = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCam.enabled = true;
        fpsCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Tab))
        {
            isFPS = !isFPS;
        }
        else if(!Input.GetKey(KeyCode.Mouse1))
        {
            isFPS = false;
        }
        CamSwitch();
    }

    void CamSwitch()
    {


        if (isFPS)
        {
            mainCam.enabled = false;
            fpsCam.enabled = true;
        }
        else
        {
            mainCam.enabled = true;
            fpsCam.enabled = false;
        }
    }
}
