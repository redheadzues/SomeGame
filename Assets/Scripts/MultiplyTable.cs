using UnityEngine;

public class MultiplyTable : ObjectsPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _DuplicateOffsetX;
    [SerializeField] private ParticleSystem _particleSystem;

    private StickmanFlightOperator _lastDuplicate;

    private void Awake()
    {
        InitializePool(_template);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<StickmanFlightOperator>(out StickmanFlightOperator flyOperator))
            if (flyOperator != _lastDuplicate)
            {
                Vector3 collisionPoint = collision.contacts[0].point;
                MultyplierStickman(flyOperator.Direction, collisionPoint);
                _particleSystem.transform.position = collisionPoint;
                _particleSystem.Play();
            }
                
    }

    private void MultyplierStickman(Vector3 direction, Vector3 point)
    {
        if(TryGetObject(out GameObject stickman))
        {
            if(stickman.gameObject.TryGetComponent<StickmanFlightOperator>(out StickmanFlightOperator flyOperator))
            {
                flyOperator.gameObject.SetActive(true);
                flyOperator.transform.position = DefineDuplicatePosition(point);
                flyOperator.transform.SetParent(null);
                flyOperator.StartFlying(direction);
                _lastDuplicate = flyOperator;
            }
        }
    }

    private Vector3 DefineDuplicatePosition(Vector3 point)
    {
        return new Vector3(point.x + _DuplicateOffsetX, point.y, point.z);
    }
}
