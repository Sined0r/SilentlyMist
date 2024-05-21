using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HearingEnemy : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public FirstPersonMovement player;
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

        ChaseUpdate();

        PatrolUpdate();

        AtackUpdate();
    }

    public void NoticePlayer()
    {
        _isPlayerNoticed = true;
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
