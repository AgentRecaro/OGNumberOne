using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_timeScene());
    }

    IEnumerator _timeScene()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("Mainmenu");
    }
}
