using System;
using System.Collections.Generic;
using Carlo.Way_points;
using UnityEngine;
using UnityEngine.AI;

namespace Carlo.Scripts
{
    public class FindNextTarget : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Transform target = new RectTransform();
        [SerializeField] private WayPointDatabase database;

        private void Start()
        {
            MeshAdjustments();
        }

        private void Update()
        {
        }

        private void NewTarget()
        {

        }
        
        private void MeshAdjustments()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;      
        }
    }
}