using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private ObjectPool objectPool;

    public void OnStart(ObjectPool _op)
    {
        objectPool = _op;
    }

    public void SpawnAudioComponent(Transform _t, List<AudioClip> _clips)
    {
        PooledObject _po = objectPool.SpawnFromPool("AC_RandomClip", _t.position, _t.eulerAngles);
        AudioComponent _ac = _po.GameObject.GetComponent<AudioComponent>();

        _ac.Reset();
        _ac.DisableAfterPlaying = true;
        _ac.AddAudioClipCollection("", _clips);
        _ac.Play();
    }
}
