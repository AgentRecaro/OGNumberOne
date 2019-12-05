using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static float DamageArrow;
    [SerializeField] private float Speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Speed * Time.deltaTime * gameObject.transform.right;
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider Enemy)
    {
        if (Enemy.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerMovement.Hp = PlayerMovement.Hp - DamageArrow;
        }
    }
}
