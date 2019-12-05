using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComplete : MonoBehaviour
{
    public static bool CompleteTrue = false;
    [SerializeField] private int EnemyDie = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCount.CountEnemydie == EnemyDie)
        {
            CompleteTrue = true;
        }
    }
}
