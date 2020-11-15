using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, IPooledObject, IHasAudioComponent
{
    [SerializeField] private float speed = 25;
    public float Speed { set { speed = value; } }
    [Space]
    [SerializeField] private Material[] materials;
    [Space]
    [SerializeField] private LayerMask destructionLayer;
    [Space]
    [SerializeField] private List<AudioClip> audioOnHit;

    private Renderer renderer;

    public string Key { get; set; }
    public AudioComponent AudioComponent { get; private set; }

    public System.Action<string, GameObject> OnDestruction;

    private void Awake()
    {
        AudioComponent = AudioComponent ?? GetComponent<AudioComponent>();
        renderer = renderer ?? GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & destructionLayer) != 0)
        {
            OnDestruction.Invoke(Key, gameObject);
        }

        if (other.gameObject.layer == gameObject.layer)
        {
            GameManager.Instance.AudioManager.SpawnAudioComponent(transform, audioOnHit);
            OnDestruction.Invoke(Key, gameObject);
        }
    }

    public void OnEnable()
    {
        GameManager.Instance.OnFixedUpdate += OnFixedUpdate;
    }

    public void OnDisable()
    {
        GameManager.Instance.OnFixedUpdate -= OnFixedUpdate;
    }

    public void OnStart()
    {

    }

    public void OnFixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    public void OnObjectSpawn()
    {
        Material _randomMaterial = materials[Random.Range(0, materials.Length)];

        renderer.material = _randomMaterial;
        transform.GetChild(0).GetComponent<Renderer>().material = _randomMaterial;
    }

    public void OnObjectDespawn()
    {

    }

    public void SetUpOnDestruction(System.Action<string, GameObject> _action)
    {
        OnDestruction += _action;
    }
}
