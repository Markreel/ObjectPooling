using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRewindable
{
    int MaxRecordSize { get; }

    bool IsRewinding { get; }

    List<Transform> PreviousTransforms { get; }
    List<bool> PreviousActivity { get; }

    void Record();
    void Rewind();
}
