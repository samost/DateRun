using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform _target;

    [SerializeField] private float distanceOfDetect;
    
    public Transform finish;

    private bool isWaitingPlayer = true;
    
    private MeshRenderer _girlOnEnemy;

    private void Start()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        
        _girlOnEnemy = transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, _target.position) < distanceOfDetect && isWaitingPlayer && !RobberyEvent.isRobbery)
        {
            _navMeshAgent.SetDestination(_target.position);
            isWaitingPlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!RobberyEvent.isRobbery)
        {
            switch (other.tag)
            {
                case "Man":
                    Debug.Log("Hit");
                    break;
                case "Girl":
                    _navMeshAgent.SetDestination(finish.position);
                    StartCoroutine(RobberyEvent.Instance.ActivateRobe(_girlOnEnemy));
                    break;
                default:
                    return;
            }
        }
    }
}
