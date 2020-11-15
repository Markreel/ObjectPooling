using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    private TrafficLane[] Lanes;

    private ObjectPool objectPool;
    private TimerHandler timerHandler;

    private void PopulateLanesArray()
    {
        Lanes = transform.GetComponentsInChildren<TrafficLane>();
    }

    private void ProvideLanesWithReferences()
    {
        foreach (var _lane in Lanes)
        {
            _lane.ObjectPool = objectPool;
            _lane.TrafficManager = this;
        }
    }

    private void StartSpawningOnAllLanes()
    {
        foreach (var _lane in Lanes)
        {
            ResetLaneTimer(_lane);
        }
    }

    public void ResetLaneTimer(TrafficLane _lane)
    {
        timerHandler.StartTimer("SpawnCar" + _lane.GetInstanceID(), Random.Range(_lane.MinDelayPerCar, _lane.MaxDelayPerCar), _lane.SpawnCar);
    }

    public void OnStart(ObjectPool _op, TimerHandler _th)
    {
        objectPool = _op;
        timerHandler = _th;

        PopulateLanesArray();
        ProvideLanesWithReferences();
        StartSpawningOnAllLanes();
    }

    public void OnUpdate()
    {

    }
}
