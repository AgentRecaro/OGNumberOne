using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrbFx : MonoBehaviour
{
    private bool FireOrb = false;
    private bool PrisonOrb = false;
    private bool ShockOrb = false;
    private bool IceOrb = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!FireOrb)
        {
            Destroy(GameObject.FindGameObjectWithTag("PivotFireOrb"));
            Destroy(GameObject.FindGameObjectWithTag("BladeFireCollider"));
        }
        
        if(!PrisonOrb)
        {
            Destroy(GameObject.FindGameObjectWithTag("PivotPrisonOrb"));
            Destroy(GameObject.FindGameObjectWithTag("BladePrisonCollider"));
        }
        
        if(!ShockOrb)
        {
            Destroy(GameObject.FindGameObjectWithTag("PivotShockOrb"));
            Destroy(GameObject.FindGameObjectWithTag("BladeShockCollider"));
        }
        
        if(!IceOrb)
        {
            Destroy(GameObject.FindGameObjectWithTag("PivotIceOrb"));
            Destroy(GameObject.FindGameObjectWithTag("BladeIceCollider"));
        }
    }

    public void SpawnFireOrb()
    {
        FireOrb = true;
        PrisonOrb = false;
        ShockOrb = false;
        IceOrb = false;
        if (FireOrb == true)
        {
            Instantiate(Resources.Load("PivotFireOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);

            Instantiate(Resources.Load("FireBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("FireBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
    }

    public void SpawnPrisonOrb()
    {
        FireOrb = false;
        PrisonOrb = true;
        ShockOrb = false;
        IceOrb = false;
        if (PrisonOrb == true)
        {
            Instantiate(Resources.Load("PivotPrisonOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);

            Instantiate(Resources.Load("PrisonBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("PrisonBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
    }

    public void SpawnShockOrb()
    {
        FireOrb = false;
        PrisonOrb = false;
        ShockOrb = true;
        IceOrb = false;
        if (ShockOrb == true)
        {
            Instantiate(Resources.Load("PivotShockOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);

            Instantiate(Resources.Load("ShockBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("ShockBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
    }

    public void SpawnIceOrb()
    {
        FireOrb = false;
        PrisonOrb = false;
        ShockOrb = false;
        IceOrb = true;
        if (IceOrb == true)
        {
            Instantiate(Resources.Load("PivotIceOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);

            Instantiate(Resources.Load("IceBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("IceBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
    }
}
