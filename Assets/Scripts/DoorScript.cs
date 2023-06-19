using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator Anim;
    private AudioSource myPlayer;

    [SerializeField] AudioClip CabinSound;
    [SerializeField] AudioClip RoomSound;
    [SerializeField] AudioClip HouseSound;
    [SerializeField] bool isCabin;
    [SerializeField] bool isRoom;
    [SerializeField] bool isHouse;

    public bool isOpen = false; //With public static ALL doors would open
    public bool isLocked;
    public string doorType;

    void Start()
    {
        myPlayer = GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isCabin == true)
        {
            doorType = "Bronze";
            if (SaveScript.bronzeKey == true)
            {
                isLocked = false;
            }
        }
        if (isRoom == true)
        {
            doorType = "Silver";
            if (SaveScript.silverKey == true)
            {
                isLocked = false;
            }
        }
        if (isHouse == true)
        {
            doorType = "Gold";
            if (SaveScript.goldKey == true)
            {
                isLocked = false;
            }
        }
    }

    public void DoorOpen()
    {
        if (isOpen == false)
        {
            Anim.SetTrigger("Open");
            isOpen = true;
            if (isCabin == true)
            {
                myPlayer.clip = CabinSound;
                myPlayer.Play();
            }
            if (isRoom == true)
            {
                myPlayer.clip = RoomSound;
                myPlayer.Play();
            }
            if (isHouse == true)
            {
                myPlayer.clip = HouseSound;
                myPlayer.Play();
            }
        }
        else if (isOpen == true)
        {
            Anim.SetTrigger("Close");
            isOpen = false;
            if (isCabin == true)
            {
                myPlayer.clip = CabinSound;
                myPlayer.Play();
            }
            if (isRoom == true)
            {
                myPlayer.clip = RoomSound;
                myPlayer.Play();
            }
            if (isHouse == true)
            {
                myPlayer.clip = HouseSound;
                myPlayer.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isLocked == false)
            {
                if (isOpen == false)
                {
                    Anim.SetTrigger("Open");
                    isOpen = true;
                }
            }
        }
    }
}