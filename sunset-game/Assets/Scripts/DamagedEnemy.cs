using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamagedEnemy : MonoBehaviour
{
    public bool dentro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dentro)
        {
            this.GetComponent<NavMeshAgent>().speed = 0f;
        }
        else
        {
            this.GetComponent<NavMeshAgent>().speed = 3.5f;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("DamagedEnemy"))
        {
            dentro = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("DamagedEnemy"))
        {
            dentro = false;
        }
    }
}
