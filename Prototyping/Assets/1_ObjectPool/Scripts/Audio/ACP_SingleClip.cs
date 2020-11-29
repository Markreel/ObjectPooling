using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACP_SingleClip : AC_SingleClip, IPooledObject
{
    public string Key { get; set; }
    public ObjectPool ObjectPool { get; set; }

    protected override void Disable()
    {
        ObjectPool.DespawnFromPool(Key, gameObject);
    }

    public void OnObjectDespawn()
    {
        
    }

    public void OnObjectSpawn()
    {
        
    }

}
