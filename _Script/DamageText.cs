using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public static bool DamageSwordOn = false;
    public static bool DamageFireOn = false;
    public static bool DamagePoisonOn = false;
    public static bool DamageShockOn = false;
    private Vector3 posy;
    [SerializeField] private Text TextDamage = null;
    // Start is called before the first frame update
    void Start()
    {
        if (DamageSwordOn == true)
        {
            TextDamage.text = "" + PlayerMovement.Damage;
            DamageFireOn = false;
            DamagePoisonOn = false;
        }
        
        if (DamageFireOn == true)
        {
            TextDamage.text = "" + Enemy.DamageFire;
            DamageSwordOn = false;
            DamagePoisonOn = false;
        }
        
        if (DamagePoisonOn == true)
        {
            TextDamage.text = "" + Enemy.DamagePoison;
            DamageSwordOn = false;
            DamageFireOn = false;
        }
        
        if (DamageShockOn == true)
        {
            TextDamage.text = "" + Enemy.DamageShock;
        }
    }

    // Update is called once per frame
    void Update()
    {
        posy = transform.position;
        posy.y += 0.2f * Time.deltaTime;
        transform.position = posy;
        Destroy(gameObject,0.5f);
    }
}
