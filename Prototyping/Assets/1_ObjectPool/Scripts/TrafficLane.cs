using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLane : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    public Transform[] SpawnPoints { get { return spawnPoints; } }

    [SerializeField] private float speed = 25;
    public float Speed { get { return speed; } }

    //[SerializeField] private bool randomSpeed = false;
    //[SerializeField] private float minSpeed = 10;
    //[SerializeField] private float maxSpeed = 50;

    [Space]

    [SerializeField] private float minDelayPerCar = 0;
    public float MinDelayPerCar { get { return minDelayPerCar; } }
    [SerializeField] private float maxDelayPerCar = 2;
    public float MaxDelayPerCar { get { return maxDelayPerCar; } }

    public ObjectPool ObjectPool { private get; set; }
    public TrafficManager TrafficManager { private get; set; }

    public void SpawnCar()
    {
        Transform _rt = spawnPoints[Random.Range(0, spawnPoints.Length)];
        PooledObject _po = ObjectPool.SpawnFromPool("Car", _rt.position, _rt.eulerAngles);

        if(_po != null && _po.GameObject != null)
        {
            _po.GameObject.GetComponent<Car>().Speed = speed;
        }

        TrafficManager.ResetLaneTimer(this);
    }
}
