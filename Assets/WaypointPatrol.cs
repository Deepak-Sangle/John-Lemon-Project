using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent ghost;
    public Transform[] waypoints;
    int index;
    void Start()
    {
        ghost.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if(ghost.remainingDistance < ghost.stoppingDistance){
            index=(index+1)%(waypoints.Length);
            ghost.SetDestination(waypoints[index].position);
        }
    }
}
