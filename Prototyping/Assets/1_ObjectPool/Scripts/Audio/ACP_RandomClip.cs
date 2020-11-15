using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACP_RandomClip : AC_RandomClip, IPooledObject
{
    public string Key { get; set; }

    public System.Action<string, GameObject> OnDestruction;

    public void OnObjectDespawn()
    {
        
    }

    public void OnObjectSpawn()
    {
        
    }

    public void SetUpOnDestruction(System.Action<string, GameObject> _action)
    {
        OnDestruction += _action;
    }
}
