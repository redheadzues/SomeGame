using UnityEngine;

public class EnemyCastleBreaker : CastleBreaker
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out StickmanFlightOperator flyOperator))
        {
            Destroy();
        }
    }
}
