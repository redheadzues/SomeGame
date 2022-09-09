using System.Collections;
using UnityEngine;

public class StickmanFlightOperator : StickmanAnimator
{
    [SerializeField] private float _speed;
    [SerializeField] private float _coroutineDelay;
    
    public Vector3 Direction { get; private set; }

    private Coroutine _coroutine;

    public void StartFlying(Vector3 direction)
    {
        SetDirection(direction);

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnFlying(direction));
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

    private IEnumerator OnFlying(Vector3 direction)
    {
        var waitingTime = new WaitForSeconds(_coroutineDelay);

        while(gameObject.activeSelf == true)
        {
            Fly(direction);
            yield return waitingTime;
        }
    }
}
