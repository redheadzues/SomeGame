using System.Collections;
using UnityEngine;

public class StickmanAppearer : StickmanAnimator
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _coroutineDelay;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_targetPosition != null)
            BeginCoroutine();            
    }

    public void SetTarget(Transform target)
    {
        _targetPosition = target.position;
    }

    private void BeginCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnMove());
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private IEnumerator OnMove()
    {
        PlayRun();

        while(transform.position != _targetPosition)
        {
            Move();

            yield return new WaitForSeconds(_coroutineDelay);
        }

        PlayIdle();
    }
}
