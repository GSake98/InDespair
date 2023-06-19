using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    [SerializeField] GameObject bloodParticleOff;

    void Start()
    {
        StartCoroutine(SwitchBloodOffCoroutine());
    }

    void Update()
    {
        StartCoroutine(SwitchBloodOffCoroutine());
    }

    IEnumerator SwitchBloodOffCoroutine()
    {
        yield return new WaitForSeconds(0.15f);
        bloodParticleOff.gameObject.SetActive(false);
    }
}
