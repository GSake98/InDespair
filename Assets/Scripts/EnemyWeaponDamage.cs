using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] int weaponDamage = 4;
    [SerializeField] Animator hurtAnim;
    [SerializeField] AudioSource myAudio;
    [SerializeField] GameObject fpsArms;

    private bool hitActive = false;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == false)
            {
                hitActive = true;
                hurtAnim.SetTrigger("Hurt");
                SaveScript.playerHealth -= weaponDamage;
                SaveScript.healthChanged = true;
                myAudio.Play();
                // Connects FpsArms to get hit stamina
                fpsArms.GetComponent<PlayerAttacks>().attackChargesUI.fillAmount
                -= fpsArms.GetComponent<PlayerAttacks>().attackChargesAfterHit;
                fpsArms.GetComponent<PlayerAttacks>().attackCharges
                = fpsArms.GetComponent<PlayerAttacks>().attackChargesUI.fillAmount;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == true)
            {
                hitActive = false;
            }
        }
    }
}
