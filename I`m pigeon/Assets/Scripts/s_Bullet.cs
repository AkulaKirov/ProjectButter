﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class s_Bullet : MonoBehaviour
{

    public float BulletLifeTime = 5f;
    private float BulletTime = 0f;

    public GameObject particalEffect;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Bullet Hit Enemy");
            collision.gameObject.GetComponent<s_Enemy>().Hurt(10);
        }
        Debug.Log("Bullet Hit");
        Vector3 normal = collision.contacts[0].normal;
        Debug.DrawRay(collision.contacts[0].point, normal, Color.red, 10f);
        GameObject p = Instantiate(particalEffect);
        p.transform.position = collision.contacts[0].point;
        p.transform.LookAt(p.transform.position + normal);
        Destroy(gameObject);
        //Destroy(p);
    }

    void OnDestroy()
    {
        Debug.Log("Bullet Destroyed");
    }
}
