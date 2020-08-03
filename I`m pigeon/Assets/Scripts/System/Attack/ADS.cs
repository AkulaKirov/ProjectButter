using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour
{

    public Collider detectRange;
    public GameObject Bullet;
    public float coolDownTime = 5f;
    public Vector3 interceptPoint;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        detectRange = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interceptPoint != Vector3.zero)
        {
            Intercept(interceptPoint);
        }
        else
        {
            interceptPoint = Vector3.zero;
        }   
    }

    void Intercept(Vector3 point)
    {

    }

    Vector3 CaclEP()
    {
        Vector3 point = Vector3.zero;

        return point;
    }

    private Vector3 OnCollisionEnter(Collision collision)
    {
        Vector3 hit = Vector3.zero;


        return hit;
        
    }
}
