using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACP_RandomClip : AC_RandomClip, IPooledObject
{
    public ObjectPool ObjectPool { get; set; }
    public string Key { get; set; }

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
