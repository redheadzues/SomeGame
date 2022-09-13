using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StickmanLauncher))]
public class StickmanCharger : MonoBehaviour
{    
    [SerializeField] private AlliedSpawner _spawner;
    [SerializeField] private Vector3 _localPointToSetPosition;

    private GameObject _lastSpawned;
    private GameObject _waitingForCharge;
    private StickmanLauncher _launcher;

    public event UnityAction<GameObject> Charged;

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

    private void OnInstantiated(GameObject stickman)
    {
        _lastSpawned = stickman;

        if (_waitingForCharge == null)
            _waitingForCharge = stickman;
    }

    private void OnLaunchSuccessfully()
    {
        _waitingForCharge.transform.SetParent(_launcher.transform);
        _waitingForCharge.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _waitingForCharge.transform.localPosition = _localPointToSetPosition;

        Charged?.Invoke(_waitingForCharge);

        _waitingForCharge = _lastSpawned;
    }
}
