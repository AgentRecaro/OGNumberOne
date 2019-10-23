using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCombo : MonoBehaviour
{
    private bool spawn;
    [SerializeField] private float destroycobo = 0.3f;
    [SerializeField] private float timedestroy;
    [SerializeField] private Transform position = null;

        // Start is called before the first frame update
    void Start()
    {

        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timedestroy >= 1)
        {
            timedestroy -= destroycobo * Time.deltaTime;
        }
        if (timedestroy <= 1)
        {
            spawn = false;
            Destroy(GameObject.FindGameObjectWithTag("Combo"));
            EventComboGame.Combo = 0;
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            
            if (spawn == false)
            {
                Instantiate(Resources.Load("ComBoCanvas"),position.position, Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
                spawn = true;
                timedestroy += 5;
            }
            else
            {
                timedestroy += 3;
            }

            if (timedestroy >= 10)
            {
                destroycobo = 0.6f;
            }

            if (timedestroy >= 15)
            {
                destroycobo = 1f;
            }

            if (timedestroy <= 9)
            {
                destroycobo = 0.3f;
            }
        }
    }
}
