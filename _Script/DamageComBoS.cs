using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComBoS : MonoBehaviour
{
    private Vector3 posy;
    
    // Update is called once per frame
    void Update()
    {
        posy = transform.position;
        posy.y += 0.2f * Time.deltaTime;
        transform.position = posy;
        Destroy(gameObject,0.5f);
    }
}
