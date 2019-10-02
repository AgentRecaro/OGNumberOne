using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GUI : MonoBehaviour
{
    public Text _scoreUi;
    public static int _Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreUi.text = "" + _Score;
    }
}
