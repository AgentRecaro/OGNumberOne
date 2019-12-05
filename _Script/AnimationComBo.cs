using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComBo : MonoBehaviour
{
    private Vector3 PosY;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(AnimationComboOn());
    }

    // Update is called once per frame
    void Update()
    {
//        PosY = transform.position;
//        StartCoroutine(AnimationComboOn());
//        transform.position = PosY;
    }

    IEnumerator AnimationComboOn()
    {
        PosY = transform.position;
        PosY.y = 8;
        transform.position = PosY;
        yield return new WaitForSecondsRealtime( 0.2f);
        PosY = transform.position;
        PosY.y = -8;
        transform.position = PosY;
        yield return new WaitForSecondsRealtime( 0.2f);
    }
}
