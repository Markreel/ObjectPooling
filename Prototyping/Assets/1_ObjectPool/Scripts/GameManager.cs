using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public System.Action OnUpdate;
    public System.Action OnFixedUpdate;

    public TimerHandler TimerHandler;
    public AudioManager AudioManager;
    public RewindManager RewindManager;

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
        AudioManager?.OnStart(objectPool);
        objectPool?.OnStart();
        trafficManager?.OnStart(objectPool, TimerHandler);

        OnUpdate += TimerHandler.OnUpdate;
        OnUpdate += trafficManager.OnUpdate;
        OnUpdate += RewindManager.OnUpdate;

        OnFixedUpdate += RewindManager.OnFixedUpdate;
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}