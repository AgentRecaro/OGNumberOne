using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 _camera;

    private void Start()
    {
        _camera = transform.position - GameObject.FindWithTag("Player").transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = GameObject.FindWithTag("Player").transform.position + _camera;
        transform.position = Vector3.Slerp(transform.position,newPos,0.5f);
    }
}
