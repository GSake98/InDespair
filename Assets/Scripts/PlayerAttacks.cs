using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    public float attackCharges;
    private AudioSource myAudio;
    [SerializeField] AudioClip gunShotSound;
    [SerializeField] AudioClip enfieldSound;

    [SerializeField] float maxAttackCharges = 1f;
    [SerializeField] public float attackChargesAfterHit = 1f;
    [SerializeField] public float knifeAttackChargesUsed = 0.45f;
    [SerializeField] public float batAttackChargesUsed = 0.55f;
    [SerializeField] public float axeAttackChargesUsed = 0.775f;
    [SerializeField] public float attackChargesRefill = 0.4f;
    [SerializeField] public Image attackChargesUI;
    [SerializeField] public GameObject pointer;
    [SerializeField] public GameObject gunCrosshair;
    // [SerializeField] public GameObject crossbowCrosshair;
    [SerializeField] public GameObject enfieldCrosshair;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        attackCharges = maxAttackCharges;
        pointer.gameObject.SetActive(true);
        gunCrosshair.gameObject.SetActive(false);
        enfieldCrosshair.gameObject.SetActive(false);
        // crossbowCrosshair.gameObject.SetActive(false);
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log("Attack Stamina" + attackCharges);

        if (attackCharges < maxAttackCharges)
        {
            attackChargesUI.fillAmount += attackChargesRefill * Time.deltaTime;
            attackCharges = attackChargesUI.fillAmount;
            // attackCharges += attackChargesRefill * Time.deltaTime;
        }

        if (attackCharges <= 0.01f)
        {
            attackCharges = attackChargesUI.fillAmount;
            attackCharges = 0.01f;
        }

        if (attackCharges > 0.5f)
        {
            if (Time.timeScale == 1)
            {
                // KNIFE
                if (SaveScript.haveKnife == true)
                {
                    // Mouse0 = LMB    Mouse1 = RMB    Mouse2 = SCR
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        anim.SetTrigger("KnifeLMB");
                        attackChargesUI.fillAmount -= knifeAttackChargesUsed;
                        attackCharges = attackChargesUI.fillAmount;
                        // attackCharges -= attackChargesUsed;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("KnifeRMB");
                        attackChargesUI.fillAmount -= knifeAttackChargesUsed;
                        attackCharges = attackChargesUI.fillAmount;
                        // attackCharges -= attackChargesUsed;
                    }
                }

                // BAT
                if (SaveScript.haveBat == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        anim.SetTrigger("BatLMB");
                        attackChargesUI.fillAmount -= batAttackChargesUsed;
                        attackCharges = attackChargesUI.fillAmount;
                        // attackCharges -= attackChargesUsed;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("BatRMB");
                        attackChargesUI.fillAmount -= batAttackChargesUsed;
                        attackCharges = attackChargesUI.fillAmount;
                        // attackCharges -= attackChargesUsed;
                    }
                }

                // AXE
                if (SaveScript.haveAxe == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        anim.SetTrigger("AxeLMB");
                        attackChargesUI.fillAmount -= axeAttackChargesUsed;
                        attackCharges = attackChargesUI.fillAmount;
                        // attackCharges -= attackChargesUsed;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("AxeRMB");
                        attackChargesUI.fillAmount -= axeAttackChargesUsed;
                        attackCharges = attackChargesUI.fillAmount;
                        // attackCharges -= attackChargesUsed;
                    }
                }

                // GUN
                if (SaveScript.haveGun == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("GunAimed");
                        anim.SetBool("AimGun", true);
                        pointer.gameObject.SetActive(false);
                        gunCrosshair.gameObject.SetActive(true);
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse1))
                    {
                        anim.SetBool("AimGun", false);
                        gunCrosshair.gameObject.SetActive(false);
                        pointer.gameObject.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        myAudio.clip = gunShotSound;
                        myAudio.Play();
                    }
                }

                // ENFIELD
                if (SaveScript.haveEnfield == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("EnfieldAimed");
                        anim.SetBool("AimEnfield", true);
                        pointer.gameObject.SetActive(false);
                        enfieldCrosshair.gameObject.SetActive(true);
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse1))
                    {
                        anim.SetBool("AimEnfield", false);
                        enfieldCrosshair.gameObject.SetActive(false);
                        pointer.gameObject.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        myAudio.clip = enfieldSound;
                        myAudio.Play();
                    }
                }
            }
        }

    }
}
