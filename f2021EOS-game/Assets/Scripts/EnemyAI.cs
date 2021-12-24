using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject PlayerObj;
    public NavMeshAgent agent;

    public float Distance;

    public bool aggro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(PlayerObj.transform.position, this.transform.position);

        if (Distance <= 10)
        {
            aggro = true;
        }
        if (Distance > 10)
        {
            aggro = false;
        }
        if (aggro)
        {
            agent.isStopped = false;
            agent.SetDestination(PlayerObj.transform.position);
        }
        if (!aggro)
        {
            agent.isStopped = true;
        }
    }
    
    /*
    void PlayerHit()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
    }
    */

}
