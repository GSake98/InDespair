using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] PostProcessVolume myVolume;
    [SerializeField] PostProcessProfile standard;
    [SerializeField] PostProcessProfile nightVision;
    [SerializeField] GameObject nightVisionOverlay;
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject enemyFlashlight;
//They were private i made them public static for research purposes
    private bool nightVisionON = false;
    private bool flashlightON = false;

    void Start()
    {
        nightVisionOverlay.gameObject.SetActive(false);
        enemyFlashlight.gameObject.SetActive(false);
    }

    void Update()
    {
//Toggle with N the nightvision
        if(SaveScript.batteryPower > 0.0f)
        {
            if(Input.GetKeyDown(KeyCode.N))
            {
                if(nightVisionON == false)
                {
                    myVolume.profile = nightVision;
                    nightVisionON = true;
                    nightVisionOverlay.gameObject.SetActive(true);
                    SaveScript.usesNightvision = true;
                }
                else
                {
                    myVolume.profile = standard;
                    nightVisionON = false;
                    nightVisionOverlay.gameObject.SetActive(false);
                    SaveScript.usesNightvision = false;
                }
            }
//Toggle with F the flashlight
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(flashlightON == false)
                {
                    flashlightON = true;
                    flashlight.gameObject.SetActive(true);
                    enemyFlashlight.gameObject.SetActive(true);
                    SaveScript.usesFlashlight = true;
                }
                else
                {
                    flashlightON = false;
                    flashlight.gameObject.SetActive(false);
                    enemyFlashlight.gameObject.SetActive(false);
                    SaveScript.usesFlashlight = false;
                }
            }
        }
//Switch off if no batterypower left
        if(SaveScript.batteryPower <= 0.0f)
            {
                myVolume.profile = standard;
                nightVisionON = false;
                nightVisionOverlay.gameObject.SetActive(false);
                SaveScript.usesNightvision = false;
                flashlightON = false;
                flashlight.gameObject.SetActive(false);
                enemyFlashlight.gameObject.SetActive(true);
                SaveScript.usesFlashlight = false;
            }
    }
}
