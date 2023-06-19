using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] AudioSource attackSound;
    [SerializeField] public int enemyHealth = 100;
    [SerializeField] int enemyDamageTakenByKnife = 15;
    [SerializeField] int enemyDamageTakenByBat = 20;
    [SerializeField] int enemyDamageTakenByAxe = 35;
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject enemyCollider;
    [SerializeField] GameObject knifeBloodParticle;
    [SerializeField] GameObject batBloodParticle;
    [SerializeField] GameObject axeBloodParticle;

    public bool hasDied = false;
    private AudioSource myAudio;
    private Animator anim;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
        knifeBloodParticle.gameObject.SetActive(false);
        batBloodParticle.gameObject.SetActive(false);
        axeBloodParticle.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            if (hasDied == false)
            {
                anim.SetBool("IsDead", true);
                hasDied = true;
                anim.SetTrigger("Death");
                SaveScript.enemiesChasing--;
                enemyCollider.SetActive(false);
                Destroy(enemyObject, 40f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PKnife"))
        {
            enemyHealth -= enemyDamageTakenByKnife;
            myAudio.Play();
            attackSound.Play();
            knifeBloodParticle.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("PBat"))
        {
            enemyHealth -= enemyDamageTakenByBat;
            myAudio.Play();
            attackSound.Play();
            batBloodParticle.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("PAxe"))
        {
            enemyHealth -= enemyDamageTakenByAxe;
            myAudio.Play();
            attackSound.Play();
            axeBloodParticle.gameObject.SetActive(true);
        }
    }
}
