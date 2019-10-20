using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestspawnEnemy : MonoBehaviour
{
    public Transform _position;

    public void _spawnEnemy()
    {
        Instantiate(Resources.Load("Skeleton"), new Vector3(-2.4f,-84.899f,0),Quaternion.identity);
    }
}
