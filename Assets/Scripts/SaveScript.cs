using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
//public static is available to every other script
    public static int playerHealth = 100;
    public static bool healthChanged = false;
    public static float batteryPower = 1.0f;
    public static bool batteryRefill = false;
    public static bool usesFlashlight = false;
    public static bool usesNightvision = false;
    public static int waterBottles = 0;
    public static int batteries = 0;
    public static bool knife = false;
    public static bool bat = false;
    public static bool axe = false;
    public static bool gun = false;
    public static bool crossbow = false;
    public static bool enfield = false;
    public static bool bronzeKey = false;
    public static bool silverKey = false;
    public static bool goldKey = false;
    public static int bulletClips = 0;
    public static bool arrowRefill = false;
    public static bool cartridgeRefill = false;
    public static int enemiesChasing = 0;
    public static bool optionsOpen = false;
    public static bool inventoryOpen = false;
    public static bool haveKnife = false;
    public static bool haveBat = false;
    public static bool haveAxe = false;
    public static bool haveGun = false;
    public static bool haveCrossbow = false;
    public static bool haveEnfield = false;
}
