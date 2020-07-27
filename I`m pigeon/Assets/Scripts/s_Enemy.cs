using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Enemy : MonoBehaviour
{

    Transform target;
    public int health = 100;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }

    public void Hurt(int damage)
    {
        Debug.Log("Damage");

        if (damage > health)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }
    }

    void HealthCheck()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
