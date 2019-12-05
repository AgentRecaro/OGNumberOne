﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadSceneAsync("DontDestroy",LoadSceneMode.Additive);
    }
}
