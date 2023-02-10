using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent nva;

    [SerializeField] private Transform[] patrolPos;
    private bool walkPointSet = false;
    [SerializeField] private LayerMask Player;
    [SerializeField] private float sightRange;
    private bool inSightRange;
    private int iPos;

    [SerializeField] private Transform chestGhostPos;

    private Dolls theDolls;
    [SerializeField] private float stunnedTime;

    private void Start()
    {
        nva = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //check for sight
        inSightRange = Physics.CheckSphere(transform.position, sightRange, Player);

        if (inSightRange) ChasePlayer();
        else if (!inSightRange) Patrol();
        
    }

    private void ChasePlayer()
    {
        // Look at the player
        //transform.LookAt(player.transform);

        nva.destination = target.position;
    }

    private void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) nva.SetDestination(patrolPos[iPos].position);

        Vector3 distanceToWalkPoint = transform.position - patrolPos[iPos].position;

        //Walkpoint reached
        if(distanceToWalkPoint.magnitude < 2f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        iPos = Random.Range(0, patrolPos.Length);
        walkPointSet = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void warpOnChest()
    {
        StartCoroutine(Warping());
    }

    IEnumerator Warping()
    {
        nva.isStopped = true;
        nva.Warp(chestGhostPos.position);
        yield return new WaitForSeconds(1f);
        nva.isStopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Doll")
        {
            Debug.Log("colllide with doll");
            if (other.TryGetComponent(out theDolls))
            {
                if (theDolls.isBlessed)
                {
                    StartCoroutine(CursingDoll());
                }
            }
        }
    }

    IEnumerator CursingDoll()
    {
        Debug.Log("cursing doll");
        nva.isStopped = true;
        yield return new WaitForSeconds(stunnedTime);
        theDolls.isBlessed = false;
        nva.isStopped = false;
    }
}

