using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewindComponent : MonoBehaviour
{
    public int MaxRecordSize = 250;

    protected List<DefaultRewindData> RewindDataList = new List<DefaultRewindData>();

    [SerializeField] protected UnityEvent OnStartRewinding;
    [SerializeField] protected UnityEvent OnStopRewinding;

    private void OnEnable()
    {
        GameManager.Instance.RewindManager.OnRecord += Record;
        GameManager.Instance.RewindManager.OnRewind += Rewind;

        GameManager.Instance.RewindManager.OnResetRecording += ResetRecording;

        GameManager.Instance.RewindManager.OnStartRewinding += OnStartRewinding.Invoke;
        GameManager.Instance.RewindManager.OnStopRewinding += OnStopRewinding.Invoke;
    }

    private void OnDisable()
    {
        GameManager.Instance.RewindManager.OnRecord -= Record;
        GameManager.Instance.RewindManager.OnRewind -= Rewind;

        GameManager.Instance.RewindManager.OnResetRecording -= ResetRecording;

        GameManager.Instance.RewindManager.OnStartRewinding -= OnStartRewinding.Invoke;
        GameManager.Instance.RewindManager.OnStopRewinding -= OnStopRewinding.Invoke;
    }

    protected virtual void Record()
    {
        if(RewindDataList.Count >= MaxRecordSize)
        {
            RewindDataList.RemoveAt(RewindDataList.Count-1);
        }

        RewindDataList.Insert(0, new DefaultRewindData(transform, gameObject.activeInHierarchy));
    }

    protected virtual void Rewind()
    {
        if(RewindDataList.Count <= 0) { return; }

        transform.position = RewindDataList[0].Position;
        transform.rotation = RewindDataList[0].Rotation;
        transform.localScale = RewindDataList[0].LocalScale;

        gameObject.SetActive(RewindDataList[0].Activity);
        RewindDataList.RemoveAt(0);
    }

    protected virtual void ResetRecording()
    {
        RewindDataList.Clear();
    }
}

public class DefaultRewindData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 LocalScale;

    public bool Activity;

    public DefaultRewindData(Transform _transform, bool _activity)
    {
        Position = _transform.position;
        Rotation = _transform.rotation;
        LocalScale = _transform.localScale;

        Activity = _activity;
    }
}
