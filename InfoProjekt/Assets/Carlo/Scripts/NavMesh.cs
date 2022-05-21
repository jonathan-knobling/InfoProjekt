using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    private List<Transform> possiblePositions;

    void Start()
    {
        MeshAdjustments();
    }

    void Update()
    {
        agent.SetDestination((target.position));
    }

    void MeshAdjustments()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;      
    }
}

