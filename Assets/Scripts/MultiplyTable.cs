using UnityEngine;

public class MultiplyTable : ObjectsPool
{
    [SerializeField] private StickmanFlightOperator _template;
    [SerializeField] private float _DuplicateOffsetX;

    private StickmanFlightOperator _lastDuplicate;

    private void Start()
    {
        InitializePool(_template);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<StickmanFlightOperator>(out StickmanFlightOperator flyOperator))
            if (flyOperator != _lastDuplicate)
            {
                var collisionPoint = collision.contacts[0].point;
                MultyplierStickman(flyOperator.Direction, collisionPoint);
            }
                
    }

    private void MultyplierStickman(Vector3 direction, Vector3 point)
    {
        if(TryGetObject(out StickmanAnimator stickman))
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
