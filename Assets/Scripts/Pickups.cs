using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickups : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] float distance = 5f;
    [SerializeField] GameObject doorMessage;
    [SerializeField] GameObject pickupMessage;
    [SerializeField] TextMeshProUGUI doorText;
    [SerializeField] GameObject playerArms;

    private LayerMask mask;
    private AudioSource myPlayerSource;
    private float rayDistance;
    private bool canSeePickup = false;
    private bool canSeeDoor = false;


    void Start()
    {
        playerArms.gameObject.SetActive(false);
        doorMessage.gameObject.SetActive(false);
        pickupMessage.gameObject.SetActive(false);
        rayDistance = distance;
        myPlayerSource = GetComponent<AudioSource>();
        mask = LayerMask.GetMask("Pickups");
    }


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, mask))
        {
            if (hit.transform.tag == "WaterBottle")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.waterBottles < 6)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.waterBottles += 1;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Battery")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.batteries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.batteries += 1;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Knife")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.knife == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.knife = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Bat")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.bat == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.bat = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Axe")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.axe == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.axe = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Gun")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.gun == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.gun = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Crossbow")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.crossbow == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.crossbow = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Enfield")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.enfield == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.enfield = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "BronzeKey")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.bronzeKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.bronzeKey = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "SilverKey")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.silverKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.silverKey = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "GoldKey")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.goldKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.goldKey = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Ammo")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.bulletClips < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.bulletClips += 1;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Arrows")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.arrowRefill == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.arrowRefill = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Cartridge")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.cartridgeRefill == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.cartridgeRefill = true;
                        myPlayerSource.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Door")
            {
                canSeeDoor = true;
                if (hit.transform.gameObject.GetComponent<DoorScript>().isLocked == false)
                {
                    if (hit.transform.gameObject.GetComponent<DoorScript>().isOpen == false)
                    {
                        doorText.text = "Press E to open.";
                    }
                    if (hit.transform.gameObject.GetComponent<DoorScript>().isOpen == true)
                    {
                        doorText.text = "Press E to close.";
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.gameObject.SendMessage("DoorOpen");
                    }
                }
                else if (hit.transform.gameObject.GetComponent<DoorScript>().isLocked == true)
                {
                    doorText.text = "You need the " + 
                    hit.transform.gameObject.GetComponent<DoorScript>().doorType + " Key.";
                }
                
            }
            else
            {

                canSeePickup = false;
                canSeeDoor = false;
            }
        }
        //There can be one value or the other no need for else if and force them to look far for pickup
        if (canSeePickup == true)
        {
            pickupMessage.gameObject.SetActive(true);
            rayDistance = 1000f;
        }

        if (canSeePickup == false)
        {
            pickupMessage.gameObject.SetActive(false);
            rayDistance = distance;
        }
        canSeePickup = false; // Needed so we don't have bugs in code.

        if (canSeeDoor == true)
        {
            doorMessage.gameObject.SetActive(true);
            rayDistance = 1000f;
        }

        if (canSeeDoor == false)
        {
            doorMessage.gameObject.SetActive(false);
            rayDistance = distance;
        }
    }
}
