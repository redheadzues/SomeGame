using UnityEngine;

public abstract class DirectionFinder : MonoBehaviour
{
    [SerializeField] private Vector3 _centerPoint;
    [SerializeField] protected Transform _launcher;

    private const float _half = 0.5f;
    private const float _zero = 0;
    
    protected void Initialize(Vector3 centerPoint, Transform launcher)
    {
        _centerPoint = centerPoint;
        _launcher = launcher;
    }

    protected Vector3 GetNormalizedVector()
    {
        var offsetCenterZ = _centerPoint.z + (_centerPoint.z - _launcher.position.z) * _half;
        var offsetCenter = new Vector3(_centerPoint.x, _centerPoint.y, offsetCenterZ);
        var distance = offsetCenter - _launcher.position;

        return new Vector3(distance.x, _zero, distance.z).normalized;
    }
}
