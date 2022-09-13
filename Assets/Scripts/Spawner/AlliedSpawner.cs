using UnityEngine;
using UnityEngine.Events;

public class AlliedSpawner : ObjectsPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private StickmanLauncher _launcher;
    [SerializeField] private Transform _startMovePosition;

    public event UnityAction<GameObject> Instantiated;

    private void Awake()
    {
        InitializePool(_template);
    }

    private void OnEnable()
    {
        _launcher.Successfully += OnLaunched;
    }

    private void Start()
    {
        Spawn();
    }

    private void OnDisable()
    {
        _launcher.Successfully -= OnLaunched;
    }

    private void Spawn()
    {
        if (TryGetObject(out GameObject stickman))
        {
            if(stickman.TryGetComponent<StickmanAppearer>(out StickmanAppearer appearer))
                appearer.SetTarget(_startMovePosition);

            SetStickman(stickman);
            Instantiated?.Invoke(stickman);
        }
    }
    
    private void SetStickman(GameObject stickman)
    {
        stickman.transform.position = transform.position;
        stickman.transform.rotation = Quaternion.Euler(Vector3.zero);
        stickman.SetActive(true);
    }

    private void OnLaunched()
    {
        Spawn();
    }
}
