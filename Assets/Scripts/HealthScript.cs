using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;

    void Start()
    {
// Won't work without "%"
        healthText.text = SaveScript.playerHealth + "%"; 
    }


    void Update()
    {
//Forces to update health after changing to false again for a brief second
        if(SaveScript.healthChanged == true)
        {
            SaveScript.healthChanged = false;
            healthText.text = SaveScript.playerHealth + "%";
        } 
    }
}
