using System.Collections;
using UnityEngine;

public class StickmanFlightOperator : StickmanAnimator
{
    [SerializeField] private float _speed;
    [SerializeField] private float _coroutineDelay;
    [SerializeField] private SpawnerDeathParticle _deathParticle;
    
    private Coroutine _coroutine;
    public Vector3 Direction { get; private set; }

    private void OnValidate()
    {
        _deathParticle = FindObjectOfType<SpawnerDeathParticle>();
    }

    public void StartFlying(Vector3 direction)
    {
        SetDirection(direction);

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnFlying(direction));
    }

    public void Die(Vector3 point)
    {
        _deathParticle.SetParticle(point);
        gameObject.SetActive(false);
    }

    private void SetDirection(Vector3 direction)
    {
        Direction = direction; 
    }
    
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void Fly(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
    }

    private void RotateOnDirection(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.down, direction);
    }

    private void PrepareForFlight(Vector3 direction)
    {
        PlayFly();
        RotateOnDirection(direction);
    }

    private IEnumerator OnFlying(Vector3 direction)
    {
        var waitingTime = new WaitForSeconds(_coroutineDelay);

        PrepareForFlight(direction);

        while(gameObject.activeSelf == true)
        {
            Fly(direction);
            yield return waitingTime;
        }
    }
}
