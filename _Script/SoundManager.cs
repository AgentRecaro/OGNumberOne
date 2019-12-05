using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static float SoundSFXValue;
    [SerializeField] private AudioClip SoundFx = null;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundFx);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = SoundSFXValue;
        Destroy(gameObject,4);
    }
}
