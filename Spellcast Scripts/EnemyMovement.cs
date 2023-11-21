using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerCombat>().isAlive())
        {
            agent.SetDestination(target.position);
        }
    }

    public float distance()
    {
        Vector3 newVector = this.transform.position - target.position;
        return newVector.magnitude;
    }
}
