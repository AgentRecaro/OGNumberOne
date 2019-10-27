﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    private Vector3 posx;
    private void Update()
    {
        posx = transform.position;
        if (transform.position.x <= 7)
        {
            posx.x += 0.01f;
        }

        transform.position = posx;
    }
}
