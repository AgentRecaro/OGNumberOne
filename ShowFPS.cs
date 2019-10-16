﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    private float deltaTime;
    [SerializeField] private Text FPSText = null;

    // Update is called once per frame
    void Update()
    {
     deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
     float FPS = 1.0f / deltaTime;
     FPSText.text = Mathf.Ceil(FPS).ToString();
    }
}