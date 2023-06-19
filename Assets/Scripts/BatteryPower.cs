using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] Image batteryUI;
    [SerializeField] float FLdrainTime = 20f;
    [SerializeField] float NVdrainTime = 15f;
    [SerializeField] float power;

    void Update()
    {
//Trigger the refill
        if(SaveScript.batteryRefill == true)
        {
            SaveScript.batteryRefill = false;
            batteryUI.fillAmount = 1.0f;   

            power = batteryUI.fillAmount;
            SaveScript.batteryPower = power;
        }
//Less battery consumed while using flashlight
        if(SaveScript.usesFlashlight == true)
        {
            batteryUI.fillAmount -= 1.0f / FLdrainTime * Time.deltaTime;
            power = batteryUI.fillAmount;
            SaveScript.batteryPower = power;
        }
//Less battery consumed while using NightVision
        if(SaveScript.usesNightvision == true)
        {
            batteryUI.fillAmount -= 1.0f / NVdrainTime * Time.deltaTime;
            power = batteryUI.fillAmount;
            SaveScript.batteryPower = power;
        }
    }
}
