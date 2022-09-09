using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StickmanLauncher))]
public class StickmanCharger : MonoBehaviour
{    
    [SerializeField] private AlliedSpawner _spawner;
    [SerializeField] private Vector3 _localPointToSetPosition;

    private StickmanAnimator _lastSpawned;
    private StickmanLauncher _launcher;

    public event UnityAction<StickmanAnimator> Charged;

    private void Awake()
    {
        _launcher = GetComponent<StickmanLauncher>();
    }

    private void OnEnable()
    {
        _launcher.Successfully += OnLaunchSuccessfully;
        _spawner.Instantiated += OnInstantiated;
    }

    private void OnDisable()
    {
        _launcher.Successfully -= OnLaunchSuccessfully;
        _spawner.Instantiated -= OnInstantiated;
    }

    private void OnInstantiated(StickmanAnimator stickman)
    {
        _lastSpawned = stickman;
    }

    private void OnLaunchSuccessfully()
    {
        _lastSpawned.transform.SetParent(_launcher.transform);
        _lastSpawned.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _lastSpawned.transform.localPosition = _localPointToSetPosition;
        Charged?.Invoke(_lastSpawned);
    }
}
