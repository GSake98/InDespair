using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool inventoryON;
    private AudioSource mySource;

    [SerializeField] Animator animator;
    [SerializeField] GameObject inventoryMenu;
    [SerializeField] GameObject playerArms;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject crossbow;
    [SerializeField] GameObject enfield;

    [SerializeField] AudioClip weaponChange;
    [SerializeField] AudioClip waterDrink;
    [SerializeField] AudioClip batteryPlugin;
    // [SerializeField] AudioClip gunShot;
    // [SerializeField] AudioClip arrowShot;
    // [SerializeField] AudioClip enfieldShot;

    //WaterBottles
    [SerializeField] GameObject waterBottleImage1;
    [SerializeField] GameObject waterBottleButton1;
    [SerializeField] GameObject waterBottleImage2;
    [SerializeField] GameObject waterBottleButton2;
    [SerializeField] GameObject waterBottleImage3;
    [SerializeField] GameObject waterBottleButton3;
    [SerializeField] GameObject waterBottleImage4;
    [SerializeField] GameObject waterBottleButton4;
    [SerializeField] GameObject waterBottleImage5;
    [SerializeField] GameObject waterBottleButton5;
    [SerializeField] GameObject waterBottleImage6;
    [SerializeField] GameObject waterBottleButton6;

    //Batteries
    [SerializeField] GameObject batteryImage1;
    [SerializeField] GameObject batteryButton1;
    [SerializeField] GameObject batteryImage2;
    [SerializeField] GameObject batteryButton2;
    [SerializeField] GameObject batteryImage3;
    [SerializeField] GameObject batteryButton3;
    [SerializeField] GameObject batteryImage4;
    [SerializeField] GameObject batteryButton4;

    //Weapons
    [SerializeField] GameObject knifeImage;
    [SerializeField] GameObject knifeButton;
    [SerializeField] GameObject batImage;
    [SerializeField] GameObject batButton;
    [SerializeField] GameObject axeImage;
    [SerializeField] GameObject axeButton;
    [SerializeField] GameObject gunImage;
    [SerializeField] GameObject gunButton;
    [SerializeField] GameObject crossbowImage;
    [SerializeField] GameObject crossbowButton;
    [SerializeField] GameObject enfieldImage;
    [SerializeField] GameObject enfieldButton;

    //Keys
    [SerializeField] GameObject bronzeKey;
    [SerializeField] GameObject silverKey;
    [SerializeField] GameObject goldKey;

    //Ammo
    [SerializeField] GameObject bulletClipImage1;
    [SerializeField] GameObject bulletClipButton1;
    [SerializeField] GameObject bulletClipImage2;
    [SerializeField] GameObject bulletClipButton2;
    [SerializeField] GameObject bulletClipImage3;
    [SerializeField] GameObject bulletClipButton3;
    [SerializeField] GameObject bulletClipImage4;
    [SerializeField] GameObject bulletClipButton4;
    [SerializeField] GameObject arrowImage;
    [SerializeField] GameObject arrowButton;
    [SerializeField] GameObject cartridgeImage;
    [SerializeField] GameObject cartridgeButton;

    // Other scripts
    EnemyAttack enemyAttack;

    void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
        inventoryON = false;
        Cursor.visible = false;
        mySource = GetComponent<AudioSource>();
        //animator = GetComponent<Animator>();

        //WaterBottles
        waterBottleImage1.gameObject.SetActive(false);
        waterBottleButton1.gameObject.SetActive(false);
        waterBottleImage2.gameObject.SetActive(false);
        waterBottleButton2.gameObject.SetActive(false);
        waterBottleImage3.gameObject.SetActive(false);
        waterBottleButton3.gameObject.SetActive(false);
        waterBottleImage4.gameObject.SetActive(false);
        waterBottleButton4.gameObject.SetActive(false);
        waterBottleImage5.gameObject.SetActive(false);
        waterBottleButton5.gameObject.SetActive(false);
        waterBottleImage6.gameObject.SetActive(false);
        waterBottleButton6.gameObject.SetActive(false);

        //Batteries
        batteryImage1.gameObject.SetActive(false);
        batteryButton1.gameObject.SetActive(false);
        batteryImage2.gameObject.SetActive(false);
        batteryButton2.gameObject.SetActive(false);
        batteryImage3.gameObject.SetActive(false);
        batteryButton3.gameObject.SetActive(false);
        batteryImage4.gameObject.SetActive(false);
        batteryButton4.gameObject.SetActive(false);

        //Weapons
        knifeImage.gameObject.SetActive(false);
        knifeButton.gameObject.SetActive(false);
        batImage.gameObject.SetActive(false);
        batButton.gameObject.SetActive(false);
        axeImage.gameObject.SetActive(false);
        axeButton.gameObject.SetActive(false);
        gunImage.gameObject.SetActive(false);
        gunButton.gameObject.SetActive(false);
        crossbowImage.gameObject.SetActive(false);
        crossbowButton.gameObject.SetActive(false);
        enfieldImage.gameObject.SetActive(false);
        enfieldButton.gameObject.SetActive(false);

        //Keys
        bronzeKey.gameObject.SetActive(false);
        silverKey.gameObject.SetActive(false);
        goldKey.gameObject.SetActive(false);


        //Ammo
        bulletClipImage1.gameObject.SetActive(false);
        bulletClipButton1.gameObject.SetActive(false);
        bulletClipImage2.gameObject.SetActive(false);
        bulletClipButton2.gameObject.SetActive(false);
        bulletClipImage3.gameObject.SetActive(false);
        bulletClipButton3.gameObject.SetActive(false);
        bulletClipImage4.gameObject.SetActive(false);
        bulletClipButton4.gameObject.SetActive(false);
        arrowImage.gameObject.SetActive(false);
        arrowButton.gameObject.SetActive(false);
        cartridgeImage.gameObject.SetActive(false);
        cartridgeButton.gameObject.SetActive(false);

    }


    void Update()
    {
        //Toggle inventory ON and OFF
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryON == false)
            {
                inventoryMenu.gameObject.SetActive(true);
                inventoryON = true;
                SaveScript.inventoryOpen = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
                // SaveScript.haveKnife = false;
                // SaveScript.haveBat = false;
                // SaveScript.haveAxe = false;
            }

            else if (inventoryON == true)
            {
                inventoryMenu.gameObject.SetActive(false);
                inventoryON = false;
                SaveScript.inventoryOpen = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }

        CheckInventory();
        CheckWeapons();
        CheckKeys();
        CheckAmmo();
    }

    void CheckInventory()
    {
        //WaterBottles
        if (SaveScript.waterBottles == 0)
        {
            waterBottleImage1.gameObject.SetActive(false);
            waterBottleButton1.gameObject.SetActive(false);
            waterBottleImage2.gameObject.SetActive(false);
            waterBottleButton2.gameObject.SetActive(false);
            waterBottleImage3.gameObject.SetActive(false);
            waterBottleButton3.gameObject.SetActive(false);
            waterBottleImage4.gameObject.SetActive(false);
            waterBottleButton4.gameObject.SetActive(false);
            waterBottleImage5.gameObject.SetActive(false);
            waterBottleButton5.gameObject.SetActive(false);
            waterBottleImage6.gameObject.SetActive(false);
            waterBottleButton6.gameObject.SetActive(false);
        }

        if (SaveScript.waterBottles == 1)
        {
            waterBottleImage1.gameObject.SetActive(true);
            waterBottleButton1.gameObject.SetActive(true);
            waterBottleImage2.gameObject.SetActive(false);
            waterBottleButton2.gameObject.SetActive(false);
            waterBottleImage3.gameObject.SetActive(false);
            waterBottleButton3.gameObject.SetActive(false);
            waterBottleImage4.gameObject.SetActive(false);
            waterBottleButton4.gameObject.SetActive(false);
            waterBottleImage5.gameObject.SetActive(false);
            waterBottleButton5.gameObject.SetActive(false);
            waterBottleImage6.gameObject.SetActive(false);
            waterBottleButton6.gameObject.SetActive(false);
        }

        if (SaveScript.waterBottles == 2)
        {
            waterBottleImage1.gameObject.SetActive(true);
            waterBottleButton1.gameObject.SetActive(false);
            waterBottleImage2.gameObject.SetActive(true);
            waterBottleButton2.gameObject.SetActive(true);
            waterBottleImage3.gameObject.SetActive(false);
            waterBottleButton3.gameObject.SetActive(false);
            waterBottleImage4.gameObject.SetActive(false);
            waterBottleButton4.gameObject.SetActive(false);
            waterBottleImage5.gameObject.SetActive(false);
            waterBottleButton5.gameObject.SetActive(false);
            waterBottleImage6.gameObject.SetActive(false);
            waterBottleButton6.gameObject.SetActive(false);
        }

        if (SaveScript.waterBottles == 3)
        {
            waterBottleImage1.gameObject.SetActive(true);
            waterBottleButton1.gameObject.SetActive(false);
            waterBottleImage2.gameObject.SetActive(true);
            waterBottleButton2.gameObject.SetActive(false);
            waterBottleImage3.gameObject.SetActive(true);
            waterBottleButton3.gameObject.SetActive(true);
            waterBottleImage4.gameObject.SetActive(false);
            waterBottleButton4.gameObject.SetActive(false);
            waterBottleImage5.gameObject.SetActive(false);
            waterBottleButton5.gameObject.SetActive(false);
            waterBottleImage6.gameObject.SetActive(false);
            waterBottleButton6.gameObject.SetActive(false);
        }

        if (SaveScript.waterBottles == 4)
        {
            waterBottleImage1.gameObject.SetActive(true);
            waterBottleButton1.gameObject.SetActive(false);
            waterBottleImage2.gameObject.SetActive(true);
            waterBottleButton2.gameObject.SetActive(false);
            waterBottleImage3.gameObject.SetActive(true);
            waterBottleButton3.gameObject.SetActive(false);
            waterBottleImage4.gameObject.SetActive(true);
            waterBottleButton4.gameObject.SetActive(true);
            waterBottleImage5.gameObject.SetActive(false);
            waterBottleButton5.gameObject.SetActive(false);
            waterBottleImage6.gameObject.SetActive(false);
            waterBottleButton6.gameObject.SetActive(false);
        }

        if (SaveScript.waterBottles == 5)
        {
            waterBottleImage1.gameObject.SetActive(true);
            waterBottleButton1.gameObject.SetActive(false);
            waterBottleImage2.gameObject.SetActive(true);
            waterBottleButton2.gameObject.SetActive(false);
            waterBottleImage3.gameObject.SetActive(true);
            waterBottleButton3.gameObject.SetActive(false);
            waterBottleImage4.gameObject.SetActive(true);
            waterBottleButton4.gameObject.SetActive(false);
            waterBottleImage5.gameObject.SetActive(true);
            waterBottleButton5.gameObject.SetActive(true);
            waterBottleImage6.gameObject.SetActive(false);
            waterBottleButton6.gameObject.SetActive(false);
        }

        if (SaveScript.waterBottles == 6)
        {
            waterBottleImage1.gameObject.SetActive(true);
            waterBottleButton1.gameObject.SetActive(true);
            waterBottleImage2.gameObject.SetActive(true);
            waterBottleButton2.gameObject.SetActive(false);
            waterBottleImage3.gameObject.SetActive(true);
            waterBottleButton3.gameObject.SetActive(false);
            waterBottleImage4.gameObject.SetActive(true);
            waterBottleButton4.gameObject.SetActive(false);
            waterBottleImage5.gameObject.SetActive(true);
            waterBottleButton5.gameObject.SetActive(false);
            waterBottleImage6.gameObject.SetActive(true);
            waterBottleButton6.gameObject.SetActive(true);
        }

        //Batteries
        if (SaveScript.batteries == 0)
        {
            batteryImage1.gameObject.SetActive(false);
            batteryButton1.gameObject.SetActive(false);
            batteryImage2.gameObject.SetActive(false);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(false);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }

        if (SaveScript.batteries == 1)
        {
            batteryImage1.gameObject.SetActive(true);
            batteryButton1.gameObject.SetActive(true);
            batteryImage2.gameObject.SetActive(false);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(false);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.batteries == 2)
        {
            batteryImage1.gameObject.SetActive(true);
            batteryButton1.gameObject.SetActive(false);
            batteryImage2.gameObject.SetActive(true);
            batteryButton2.gameObject.SetActive(true);
            batteryImage3.gameObject.SetActive(false);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.batteries == 3)
        {
            batteryImage1.gameObject.SetActive(true);
            batteryButton1.gameObject.SetActive(false);
            batteryImage2.gameObject.SetActive(true);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(true);
            batteryButton3.gameObject.SetActive(true);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.batteries == 4)
        {
            batteryImage1.gameObject.SetActive(true);
            batteryButton1.gameObject.SetActive(false);
            batteryImage2.gameObject.SetActive(true);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(true);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(true);
            batteryButton4.gameObject.SetActive(true);
        }
    }

    void CheckKeys()
    {
        if (SaveScript.bronzeKey == true)
        {
            bronzeKey.gameObject.SetActive(true);
        }

        if (SaveScript.silverKey == true)
        {
            silverKey.gameObject.SetActive(true);
        }

        if (SaveScript.goldKey == true)
        {
            goldKey.gameObject.SetActive(true);
        }
    }

    void CheckWeapons()
    {
        if (SaveScript.knife == true)
        {
            knifeImage.gameObject.SetActive(true);
            knifeButton.gameObject.SetActive(true);
        }

        if (SaveScript.bat == true)
        {
            batImage.gameObject.SetActive(true);
            batButton.gameObject.SetActive(true);
        }

        if (SaveScript.axe == true)
        {
            axeImage.gameObject.SetActive(true);
            axeButton.gameObject.SetActive(true);
        }

        if (SaveScript.gun == true)
        {
            gunImage.gameObject.SetActive(true);
            gunButton.gameObject.SetActive(true);
        }

        if (SaveScript.crossbow == true)
        {
            crossbowImage.gameObject.SetActive(true);
            crossbowButton.gameObject.SetActive(true);
        }

        if (SaveScript.enfield == true)
        {
            enfieldImage.gameObject.SetActive(true);
            enfieldButton.gameObject.SetActive(true);
        }
    }

    void CheckAmmo()
    {
        //Gun Bullets
        if (SaveScript.bulletClips == 0)
        {
            bulletClipImage1.gameObject.SetActive(false);
            bulletClipButton1.gameObject.SetActive(false);
            bulletClipImage2.gameObject.SetActive(false);
            bulletClipButton2.gameObject.SetActive(false);
            bulletClipImage3.gameObject.SetActive(false);
            bulletClipButton3.gameObject.SetActive(false);
            bulletClipImage4.gameObject.SetActive(false);
            bulletClipButton4.gameObject.SetActive(false);
        }


        if (SaveScript.bulletClips == 1)
        {
            bulletClipImage1.gameObject.SetActive(true);
            bulletClipButton1.gameObject.SetActive(true);
            bulletClipImage2.gameObject.SetActive(false);
            bulletClipButton2.gameObject.SetActive(false);
            bulletClipImage3.gameObject.SetActive(false);
            bulletClipButton3.gameObject.SetActive(false);
            bulletClipImage4.gameObject.SetActive(false);
            bulletClipButton4.gameObject.SetActive(false);
        }

        if (SaveScript.bulletClips == 2)
        {
            bulletClipImage1.gameObject.SetActive(true);
            bulletClipButton1.gameObject.SetActive(false);
            bulletClipImage2.gameObject.SetActive(true);
            bulletClipButton2.gameObject.SetActive(true);
            bulletClipImage3.gameObject.SetActive(false);
            bulletClipButton3.gameObject.SetActive(false);
            bulletClipImage4.gameObject.SetActive(false);
            bulletClipButton4.gameObject.SetActive(false);
        }

        if (SaveScript.bulletClips == 3)
        {
            bulletClipImage1.gameObject.SetActive(true);
            bulletClipButton1.gameObject.SetActive(false);
            bulletClipImage2.gameObject.SetActive(true);
            bulletClipButton2.gameObject.SetActive(false);
            bulletClipImage3.gameObject.SetActive(true);
            bulletClipButton3.gameObject.SetActive(true);
            bulletClipImage4.gameObject.SetActive(false);
            bulletClipButton4.gameObject.SetActive(false);
        }

        if (SaveScript.bulletClips == 4)
        {
            bulletClipImage1.gameObject.SetActive(true);
            bulletClipButton1.gameObject.SetActive(false);
            bulletClipImage2.gameObject.SetActive(true);
            bulletClipButton2.gameObject.SetActive(false);
            bulletClipImage3.gameObject.SetActive(true);
            bulletClipButton3.gameObject.SetActive(false);
            bulletClipImage4.gameObject.SetActive(true);
            bulletClipButton4.gameObject.SetActive(true);
        }
        //Arrows
        if (SaveScript.arrowRefill == false)
        {
            arrowImage.gameObject.SetActive(false);
            arrowButton.gameObject.SetActive(false);
        }

        if (SaveScript.arrowRefill == true)
        {
            arrowImage.gameObject.SetActive(true);
            arrowButton.gameObject.SetActive(true);
        }
        //Cartridge
        if (SaveScript.cartridgeRefill == false)
        {
            cartridgeImage.gameObject.SetActive(false);
            cartridgeButton.gameObject.SetActive(false);
        }

        if (SaveScript.cartridgeRefill == true)
        {
            cartridgeImage.gameObject.SetActive(true);
            cartridgeButton.gameObject.SetActive(true);
        }
    }

    public void HealthUpdate()
    {
        //Can't heal more than 100
        if (SaveScript.playerHealth < 100)
        {
            SaveScript.playerHealth += 15;
            SaveScript.healthChanged = true;
            SaveScript.waterBottles -= 1;
            //Play waterDrink sound
            mySource.clip = waterDrink;
            mySource.Play();
            //Making sure it will cap at 100
            if (SaveScript.playerHealth > 100)
            {
                SaveScript.playerHealth = 100;
            }
        }

        waterBottleImage1.gameObject.SetActive(false);
        waterBottleButton1.gameObject.SetActive(false);
    }

    public void BatteryUpdate()
    {
        //play batteryPluggin sound
        mySource.clip = batteryPlugin;
        mySource.Play();
        SaveScript.batteryRefill = true;
        SaveScript.batteries -= 1;
    }

    public void MeleeKnife()
    {
        playerArms.gameObject.SetActive(true);
        knife.gameObject.SetActive(true);
        animator.SetBool("Melee", true);
        mySource.clip = weaponChange;
        mySource.Play();
        SaveScript.haveKnife = true;
        SaveScript.haveBat = false;
        SaveScript.haveAxe = false;
        SaveScript.haveGun = false;
        // SaveScript.haveCrossbow = false;
        SaveScript.haveEnfield = false;
    }

    public void MeleeBat()
    {
        playerArms.gameObject.SetActive(true);
        bat.gameObject.SetActive(true);
        animator.SetBool("Melee", true);
        mySource.clip = weaponChange;
        mySource.Play();
        SaveScript.haveKnife = false;
        SaveScript.haveBat = true;
        SaveScript.haveAxe = false;
        SaveScript.haveGun = false;
        // SaveScript.haveCrossbow = false;
        SaveScript.haveEnfield = false;
    }

    public void MeleeAxe()
    {
        playerArms.gameObject.SetActive(true);
        axe.gameObject.SetActive(true);
        animator.SetBool("Melee", true);
        mySource.clip = weaponChange;
        mySource.Play();
        SaveScript.haveKnife = false;
        SaveScript.haveBat = false;
        SaveScript.haveAxe = true;
        SaveScript.haveGun = false;
        // SaveScript.haveCrossbow = false;
        SaveScript.haveEnfield = false;
    }

    public void RangeGun()
    {
        playerArms.gameObject.SetActive(true);
        gun.gameObject.SetActive(true);
        animator.SetBool("Melee", false);
        mySource.clip = weaponChange;
        mySource.Play();
        SaveScript.haveKnife = false;
        SaveScript.haveBat = false;
        SaveScript.haveAxe = false;
        SaveScript.haveGun = true;
        // SaveScript.haveCrossbow = false;
        SaveScript.haveEnfield = false;
    }

    public void RangeCrossbow()
    {
        playerArms.gameObject.SetActive(true);
        crossbow.gameObject.SetActive(true);
        animator.SetBool("Melee", false);
        mySource.clip = weaponChange;
        mySource.Play();
        // SaveScript.haveKnife = false;
        // SaveScript.haveBat = false;
        // SaveScript.haveAxe = false;
        // SaveScript.haveGun = false;
        // SaveScript.haveCrossbow = true;
        // SaveScript.haveEnfield = false;
    }

    public void RangeEnfield()
    {
        playerArms.gameObject.SetActive(true);
        enfield.gameObject.SetActive(true);
        animator.SetBool("Melee", false);
        mySource.clip = weaponChange;
        mySource.Play();
        SaveScript.haveKnife = false;
        SaveScript.haveBat = false;
        SaveScript.haveAxe = false;
        SaveScript.haveGun = false;
        // SaveScript.haveCrossbow = false;
        SaveScript.haveEnfield = true;
    }

    public void WeaponsOff()
    {
        knife.gameObject.SetActive(false);
        bat.gameObject.SetActive(false);
        axe.gameObject.SetActive(false);
        gun.gameObject.SetActive(false);
        crossbow.gameObject.SetActive(false);
        enfield.gameObject.SetActive(false);
    }

    public void CloseInventoryAfterWeaponSelection()
    {
        if (inventoryON == true)
        {
            inventoryMenu.gameObject.SetActive(false);
            inventoryON = false;
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }
}
