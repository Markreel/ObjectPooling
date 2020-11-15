using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindManager : MonoBehaviour
{
    public bool IsRewinding;

    public System.Action OnRecord;
    public System.Action OnRewind;
    public System.Action OnResetRecording;

    public System.Action OnStartRewinding;
    public System.Action OnStopRewinding;

    private List<RewindComponent> RewindComponents = new List<RewindComponent>();

    private void Record()
    {
        OnRecord.Invoke();
    }

    private void Rewind()
    {
        OnRewind.Invoke();
    }

    private void ResetRecording()
    {
        OnResetRecording.Invoke();
    }

    public void OnFixedUpdate()
    {
        if (IsRewinding) { Rewind(); }
        else { Record(); }
    }

    public void StartRewinding()
    {
        OnStartRewinding.Invoke();
        IsRewinding = true;
    }

    public void StopRewinding()
    {
        IsRewinding = false;
        OnStopRewinding.Invoke();
        ResetRecording();
    }
}
