using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPooledObject
{
    ObjectPool ObjectPool { get; set;}
    string Key { get; set; }

    void OnObjectSpawn();
    void OnObjectDespawn();
}
