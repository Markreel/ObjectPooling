using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TimerHandler TimerHandler;
    public AudioManager AudioManager;
    public RewindManager RewindManager;

    public System.Action OnUpdate;
    public System.Action OnFixedUpdate;

    private ObjectPool objectPool;
    private TrafficManager trafficManager;

    private void Awake()
    {
        Instance = Instance ?? this;

        TimerHandler = GetComponentInChildren<TimerHandler>();
        AudioManager = GetComponentInChildren<AudioManager>();
        RewindManager = GetComponentInChildren<RewindManager>();
        objectPool = GetComponentInChildren<ObjectPool>();
        trafficManager = GetComponentInChildren<TrafficManager>();
    }

    private void Start()
    {
        AudioManager.OnStart(objectPool);
        objectPool.OnStart(this);
        trafficManager.OnStart(objectPool, TimerHandler);

        OnUpdate += TimerHandler.OnUpdate;
        OnUpdate += trafficManager.OnUpdate;
        OnFixedUpdate += RewindManager.OnFixedUpdate;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Time.timeScale += (Time.timeScale > 1 ? 1 : 0.1f); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {Time.timeScale -= (Time.timeScale > 1 ? 1 : 0.1f); }
        if (Input.GetKeyDown(KeyCode.Space)) { Time.timeScale = 1; }
        if (Input.GetKeyDown(KeyCode.R)) { RewindManager.StartRewinding(); }

        OnUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}
