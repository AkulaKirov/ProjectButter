using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Bullet : MonoBehaviour
{

    public float BulletLifeTime = 5f;
    private float BulletTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bullet Summoned");
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletTime < BulletLifeTime)
        {
            BulletTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }
        Debug.Log("Bullet Hit");
        Destroy(gameObject);
    }*/

    void OnDestroy()
    {
        Debug.Log("Bullet Destroyed");
    }
}
