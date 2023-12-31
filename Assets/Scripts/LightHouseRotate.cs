﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseRotate : MonoBehaviour
{
    [SerializeField] GameObject lightHouseObject;
    [SerializeField] float speed = 0.1f;

    void Update()
    {
        lightHouseObject.transform.Rotate(0.0f, speed, 0.0f, Space.World);
    }
}
