using UnityEngine;

[RequireComponent(typeof(StickmanFlightOperator))]
public class StickmanCollisionHandler : MonoBehaviour
{
    private StickmanFlightOperator _operator;

    private void Start()
    {
        _operator = GetComponent<StickmanFlightOperator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionPoint = collision.contacts[0].point;

        if (collision.collider.TryGetComponent(out Wall wall))
        {
            Vector3 normal = collision.contacts[0].normal;
            var reflect = Vector3.Reflect(_operator.Direction, normal);
            Vector3 direction = new Vector3(reflect.x, 0, reflect.z).normalized;
            _operator.StartFlying(direction);
        }

        if (collision.collider.TryGetComponent(out EnemyCastleBreaker castle))
            _operator.Die(collisionPoint);

        if (collision.collider.TryGetComponent(out StickmanPathFollower follower))
            _operator.Die(collisionPoint);

        if (collision.collider.TryGetComponent(out Obstacle obstacle))
            _operator.Die(collisionPoint);
    }
}
