using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMapMenu : MonoBehaviour
{
    public bool map1 = false;
    public bool map2 = false;
    public bool map3 = false;
    [SerializeField] private Transform Tmap1;
    [SerializeField] private Transform Tmap2;
    [SerializeField] private Transform Tmap3;
    [SerializeField] private Transform pivotmap;
    [SerializeField] private Transform pivotBefore;
    [SerializeField] private Transform pivotNext;
    
    
    // Start is called before the first frame update
    void Start()
    {
        map1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (map1 == true)
        {
            

        }
    }

    public void ButtonBefore()
    {
        if (map1 == true)
        {
            map2 = false;
            map3 = false;
        }

        if (map2 == true)
        {
            map1 = false;
            map3 = false;
        }

        if (map3 == true)
        {
            map1 = false;
            map2 = false;
        }
    }

    public void ButtonNext()
    {
        
    }
}
