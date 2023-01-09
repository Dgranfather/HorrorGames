using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chasing : MonoBehaviour
{
    [SerializeField] private Transform target;

    private NavMeshAgent nva;

    // Start is called before the first frame update
    void Start()
    {
        nva = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nva.destination = target.position;
    }
}
