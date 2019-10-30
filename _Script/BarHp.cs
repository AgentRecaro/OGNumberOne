using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHp : MonoBehaviour
{
    [SerializeField] private Camera _camera = null;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.back, 
            _camera.transform.rotation * Vector3.up);
    }
}
