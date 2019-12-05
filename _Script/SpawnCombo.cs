using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCombo : MonoBehaviour
{
    public static bool spawn;
    [SerializeField] private float destroycobo = 0.3f;
    [SerializeField] private float timedestroy;
    [SerializeField] private Transform position = null;

        // Start is called before the first frame update
    void Start()
    {
        position = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Transform>();
        //spawn = false;
        if (spawn == true)
        {
            Instantiate(Resources.Load("ComBoCanvas"),position.position, Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
            timedestroy = 3;
        }
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
            EventComboGame.SaveNameCombo = 0;
            EventComboGame.Combo = 0;
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {

            if (spawn == false)
            {
                DeleteDamage();
                EventComboGame.DamageOn = true;
                Instantiate(Resources.Load("ComBoCanvas"), position.position, Quaternion.identity,
                    GameObject.FindGameObjectWithTag("Canvas").transform);
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

    void DeleteDamage()
    {
        if (EventComboGame.DamageD == true)
        {
            PlayerMovement.Damage -= 10;
        }

        if (EventComboGame.DamageC == true)
        {
            PlayerMovement.Damage -= 30;
        }

        if (EventComboGame.DamageB == true)
        {
            PlayerMovement.Damage -= 60;
        }

        if (EventComboGame.DamageA == true)
        {
            PlayerMovement.Damage -= 100;
        }

        if (EventComboGame.DamageS == true)
        {
            PlayerMovement.Damage -= 150;
        }
    }
}
