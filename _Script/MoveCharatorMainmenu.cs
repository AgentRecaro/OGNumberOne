using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharatorMainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }

    public void OnStart()
    {
        transform.rotation = new Quaternion(0,180,0,0);
    }
}
