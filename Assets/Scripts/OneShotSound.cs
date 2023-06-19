using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    private AudioSource oneShot;
    private Collider col;
    [SerializeField] bool oneTime = false;
    [SerializeField] float pauseTime = 5.0f;

    void Start()
    {
        oneShot = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            oneShot.Play();
            col.enabled = false;

            if(oneTime == false)
            {
                StartCoroutine(Reset());
            }
            else
            {
                Destroy(gameObject, pauseTime);
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(pauseTime);
        col.enabled = true;
    }
}
