using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Transform target;
    private float distanceToTarget;
    private int targetNumber = 1;
    private bool hasStopped = false;
    private bool randomizer = true;
    private int nextTargetNumber;

    // TO COME BACK TO AFTER SECTION
    // public bool doorStop = false;
    // private bool stopAtDoor = false;
    // private bool doorReset = false;

    [SerializeField] float stopDistance = 2f;
    [SerializeField] float waitTime = 3.5f;
    [SerializeField] int maxTargets = 10;
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] Transform target3;
    [SerializeField] Transform target4;
    [SerializeField] Transform target5;
    [SerializeField] Transform target6;
    [SerializeField] Transform target7;
    [SerializeField] Transform target8;
    [SerializeField] Transform target9;
    [SerializeField] Transform target10;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = target1;
    }

    // TO COME BACK TO AFTER SECTION
    // public void WaitAtDoor()
    // {
    //     if (doorReset == false)
    //     {
    //         doorStop = true;
    //         doorReset = true;
    //     }
    // }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget > stopDistance)
        {
            nav.SetDestination(target.position);
            anim.SetInteger("State", 0);
            nav.isStopped = false;
            nextTargetNumber = targetNumber;
        }
        if (distanceToTarget < stopDistance)
        {
            anim.SetInteger("State", 1);
            nav.isStopped = true;
            StartCoroutine(LookAroundCoroutine());
        }
    }

    void SetTarget()
    {
        if (targetNumber == 1)
        {
            target = target1;
        }
        else if (targetNumber == 2)
        {
            target = target2;
        }
        else if (targetNumber == 3)
        {
            target = target3;
        }
        else if (targetNumber == 4)
        {
            target = target4;
        }
        else if (targetNumber == 5)
        {
            target = target5;
        }
        else if (targetNumber == 6)
        {
            target = target6;
        }
        else if (targetNumber == 7)
        {
            target = target7;
        }
        else if (targetNumber == 8)
        {
            target = target8;
        }
        else if (targetNumber == 9)
        {
            target = target9;
        }
        else if (targetNumber == 10)
        {
            target = target10;
        }
    }

    IEnumerator LookAroundCoroutine()
    {
        yield return new WaitForSeconds(waitTime);

        if (hasStopped == false)
        {
            hasStopped = true;

            if (randomizer == true)
            {
                randomizer = false;
                targetNumber = Random.Range(1, maxTargets);

                if (targetNumber == nextTargetNumber)
                {
                    targetNumber++;

                    if (targetNumber >= maxTargets)
                    {
                        targetNumber = 1;
                    }
                }
            }
            SetTarget();

            yield return new WaitForSeconds(waitTime);
            hasStopped = false;
            randomizer = true;
        }
    }
}
