using UnityEngine;

public class AlliedCastleBreacker : CastleBreaker
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out StickmanPathFollower follower))
        {
            Destroy();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            Destroy();
    }
}
