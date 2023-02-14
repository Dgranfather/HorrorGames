using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

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
    [SerializeField] private Transform grabPoint;

    public float amplitude = 1.0f;
    public float frequency = 1.0f;
    private float currentY;
    private float startY;

    [SerializeField] private Rig rig1, rig2;
    private float targetWeight1, targetWeight2;
    private bool cursing;

    public bool checkingItem = false;
    private bool onCheck = false;

    private MusicManager musicManager;
    private MusicManager2 music2Manager;

    private void Start()
    {
        nva = GetComponent<NavMeshAgent>();
        startY = transform.position.y;
        targetWeight1 = 1;
        targetWeight2 = 0;
        cursing = false;

        musicManager = FindObjectOfType<MusicManager>();
        music2Manager = FindObjectOfType<MusicManager2>();
        musicManager.PlayMusic(0);
    }

    private void Update()
    {
        //check for sight
        inSightRange = Physics.CheckSphere(transform.position, sightRange, Player);

        if (cursing)
        {
            musicManager.PlayMusic(0);
        }
        else if (inSightRange)
        {
            ChasePlayer();
            if (musicManager.GetCurrentPlaying() != 1)
            {
                musicManager.PlayMusic(1);
            }
        }
        else if (checkingItem && !inSightRange)
        {
            if (nva.remainingDistance < 0.5f && onCheck == false)
            {
                StartCoroutine(WaitChecking());
            }
            if (musicManager.GetCurrentPlaying() != 0)
            {
                musicManager.PlayMusic(0);
            }
        }
        else if (!inSightRange && !checkingItem)
        { 
            Patrol();
            if (musicManager.GetCurrentPlaying() != 0)
            {
                musicManager.PlayMusic(0);
            }
        }

        MovingUpandDown();
    }

    private void FixedUpdate()
    {
        rig1.weight = Mathf.Lerp(rig1.weight, targetWeight1, Time.deltaTime * 10f);
        rig2.weight = Mathf.Lerp(rig2.weight, targetWeight2, Time.deltaTime * 10f);
    }

    private void MovingUpandDown()
    {
        if (!cursing)
        {
            //moving up and down
            currentY = startY + Mathf.Sin(Time.time * frequency) * amplitude;
            transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
        }
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
        if (walkPointSet) /*nva.SetDestination(patrolPos[iPos].position);*/ nva.destination = patrolPos[iPos].position;

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
        if(other.gameObject.tag == "Grabable")
        {
            if (other.TryGetComponent(out theDolls))
            {
                if (theDolls.onGrab == false)
                {
                    if (theDolls.isBlessed)
                    {
                        StartCoroutine(CursingDoll());
                    }
                }
            }
        }
    }

    IEnumerator CursingDoll()
    {
        //Debug.Log("cursing doll");
        nva.isStopped = true;
        theDolls.Grab(grabPoint);
        targetWeight1 = 0;
        targetWeight2 = 1;
        cursing = true;
        music2Manager.PlayMusic2(0);
        yield return new WaitForSeconds(stunnedTime);
        theDolls.Drop();
        theDolls.isBlessed = false;
        targetWeight1 = 1;
        targetWeight2 = 0;
        cursing = false;
        nva.isStopped = false;
        music2Manager.StopMusic2();
        checkingItem = false;
    }

    public void CheckDroppedItem(Transform dropPos)
    {
        checkingItem = true;
        nva.destination = dropPos.position;
    }

    IEnumerator WaitChecking()
    {
        onCheck = true;
        Debug.Log("Remaining dis : "+nva.remainingDistance);
        yield return new WaitForSeconds(2f);
        onCheck = false;
        checkingItem = false;
    }
}

