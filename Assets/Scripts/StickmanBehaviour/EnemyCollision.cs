using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out StickmanFlightOperator flyOperator))
            gameObject.SetActive(false);
        if (collision.collider.TryGetComponent(out AlliedCastleBreacker castle))
            gameObject.SetActive(false);
    }
}
