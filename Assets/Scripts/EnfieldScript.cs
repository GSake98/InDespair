using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnfieldScript : MonoBehaviour
{
    RaycastHit hit;

    void Update()
    {
        if (SaveScript.haveEnfield == true)
        {
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 5500))
                {
                    if (hit.transform.Find("Body"))
                    {
                        hit.transform.gameObject.GetComponentInChildren<EnemyDamage>().enemyHealth -= 101;
                    }
                }
            }
        }
    }
}