using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public FirstPersonMovement player;
    public float viewAngle;
    public float damage = 1;

    private NavMeshAgent _navMeshAgent;
    public bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;
    void Start()
    {
        InitComponentLinks();

        PickNewPatrolPoint();
    }

    void Update()
    {
        
        NoticePlayerUpdate();

        ChaseUpdate();

        PatrolUpdate();

        AtackUpdate();
    }

    private void AtackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }

    private void NoticePlayerUpdate()
    {
        var derection = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, derection) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, derection, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void PatrolUpdate() 
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
        
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
