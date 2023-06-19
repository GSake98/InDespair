using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    Inventory inventory;

    private NavMeshAgent nav;
    private NavMeshHit hit;
    private bool cantSee = false;
    private bool runToPlayer = false;
    private bool isChecking = true;
    private int failedChecks = 0;
    private int tabPresses = 0;
    private float playerDistance;
    private bool changeChasingAmt = false;

    [SerializeField] Transform player;
    [SerializeField] GameObject enemy;
    [SerializeField] Animator anim;
    [SerializeField] float maxRange = 35.0f;
    [SerializeField] int maxChecks = 3;
    [SerializeField] float chaseSpeed = 15f;
    [SerializeField] float walkSpeed = 1.6f;
    [SerializeField] float attackDistance = 2.3f;
    [SerializeField] float attackRotationSpeed = 2.0f;
    [SerializeField] float checkTime = 3.0f;
    [SerializeField] GameObject hurtUI;
    [SerializeField] public GameObject chaseMusic;

    private bool startMusic = false;

    void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
        chaseMusic.GetComponent<AudioSource>().volume = 0;
        // chaseMusic.gameObject.SetActive(false);
    }

    void Update()
    {

        playerDistance = Vector3.Distance(player.position, enemy.transform.position);
        if (playerDistance < maxRange)
        {
            if (isChecking == true)
            {
                isChecking = false;

                // A command that checks all available NavMesh Areas 
                cantSee = NavMesh.Raycast(transform.position, player.position, out hit, NavMesh.AllAreas);
                if (cantSee == false)
                {
                    Debug.Log("Player can be seen.");
                    runToPlayer = true;
                    failedChecks = 0;
                }
                if (cantSee == true)
                {
                    Debug.Log("Player is not here.");
                    runToPlayer = false;
                    anim.SetInteger("State", 1);
                    failedChecks++;
                }
                // StartCoroutine(TimedCheckCoroutine());
            }
            StartCoroutine(TimedCheckCoroutine());
        }

        if (runToPlayer == true)
        {
            enemy.GetComponent<EnemyMovement>().enabled = false;
            // chaseMusic.gameObject.SetActive(true);
            // chaseMusic.gameObject.GetComponent<AudioSource>().enabled = true;
            // StartCoroutine(FadeCoroutine(chaseMusic.GetComponent<AudioSource>(), 5, 0.325f));

            if (changeChasingAmt == false)
            {
                SaveScript.enemiesChasing++;
                changeChasingAmt = true;
            }
            if (SaveScript.enemiesChasing == 1 & startMusic == false)
            {
                startMusic = true;
                // StartCoroutine(FadeCoroutine(chaseMusic.GetComponent<AudioSource>(), 5, 0.325f));
                // chaseMusic.GetComponent<AudioSource>().volume = 0.325f;
            }

            if (playerDistance > attackDistance)
            {
                nav.isStopped = false;
                anim.SetInteger("State", 2);
                nav.acceleration = 20;
                nav.SetDestination(player.position);
                nav.speed = chaseSpeed;
                hurtUI.gameObject.SetActive(false);
            }

            if (playerDistance < attackDistance - 0.5f)
            {
                nav.isStopped = true;
                Debug.Log("Attacking player.");
                anim.SetInteger("State", 3);
                nav.acceleration = 150;
                hurtUI.gameObject.SetActive(true);

                Vector3 position = (player.position - enemy.transform.position).normalized;
                Quaternion positionRotation = Quaternion.LookRotation(new Vector3(position.x, 0f, position.z));
                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, positionRotation, Time.deltaTime * attackRotationSpeed);
            }
        }
        else if (runToPlayer == false)
        {
            nav.isStopped = true;

            if (changeChasingAmt == true)
            {
                SaveScript.enemiesChasing--;
                changeChasingAmt = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            runToPlayer = true;
        }
        if (other.gameObject.CompareTag("PKnife"))
        {
            anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PBat"))
        {
            anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PAxe"))
        {
            anim.SetTrigger("CriticalReact");
        }
    }

    IEnumerator TimedCheckCoroutine()
    {
        yield return new WaitForSeconds(checkTime);
        isChecking = true;

        if (failedChecks > maxChecks)
        {
            enemy.GetComponent<EnemyMovement>().enabled = true;
            nav.isStopped = false;
            nav.speed = walkSpeed;
            failedChecks = 0;
            // StartCoroutine(FadeCoroutine(chaseMusic.GetComponent<AudioSource>(), 5, 0));

            if (SaveScript.enemiesChasing < 1)
            {
                // chaseMusic.gameObject.SetActive(false);
                startMusic = false;
                // StartCoroutine(FadeCoroutine(chaseMusic.GetComponent<AudioSource>(), 5, 0));
            }
        }
    }

    IEnumerator FadeCoroutine(AudioSource audioSource, float duration, float targetVolume)
    {
        if (targetVolume == 0.325f)
        {
            audioSource.enabled = true;
        }

        float currentTime = 0f;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        // if (targetVolume == 0)
        // {
        //     audioSource.enabled = false;
        // }

        yield break;
    }
}
