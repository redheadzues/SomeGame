using UnityEngine;
using UnityEngine.Events;

public class AlliedSpawner : ObjectsPool
{
    [SerializeField] private StickmanFlightOperator _template;
    [SerializeField] protected StickmanLauncher _launcher;

    public event UnityAction<StickmanAnimator> Instantiated;

    private void OnEnable()
    {
        _launcher.Successfully += OnLaunched;
    }

    private void Start()
    {
        InitializePool(_template);
        Spawn();
    }

    private void OnDisable()
    {
        _launcher.Successfully -= OnLaunched;
    }

    private void Spawn()
    {
        if (TryGetObject(out StickmanAnimator stickman))
        {
            stickman.gameObject.SetActive(true);
            Instantiated?.Invoke(stickman);
        }
    }    

    private void OnLaunched()
    {
        Spawn();
    }
}
