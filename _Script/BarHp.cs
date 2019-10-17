using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHp : MonoBehaviour
{
    [SerializeField] private Camera _camera = null;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.back, 
            _camera.transform.rotation * Vector3.up);
    }
}
