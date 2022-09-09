using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CastlePartBreaker : MonoBehaviour
{
    private float _forceValue = 200;
    private float _coroutineDelay = 0.01f;
    private float _resizeSpeed = 10;
    private float _targetPercentResizeScale = 0.5f;
    private float _waitBeforeResize = 2;

    private Rigidbody _rigidbody;
    private List<Vector3> _targetsSize;
    private Vector3 _baseScale;
    private int _currentIndex = 0;
        
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _targetsSize = new List<Vector3>();
        _baseScale = transform.localScale;
        InitializeTargetsSizeList();
    }

    private void InitializeTargetsSizeList()
    {
        _targetsSize.Add(transform.localScale * _targetPercentResizeScale);
        _targetsSize.Add(_baseScale);
        _targetsSize.Add(Vector3.zero);
    }

    public void Activate()
    {
        RemoveKinematic();
        Move();
        StartCoroutine(OnDecrease());
    }

    private void RemoveKinematic()
    {
        _rigidbody.isKinematic = false;
    }

    private void Move()
    {
        _rigidbody.AddForce(-Vector3.one * _forceValue);
    }

    private void ChangeScale(Vector3 targetScale)
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, transform.localScale.x * _resizeSpeed * Time.deltaTime);
    }

    private IEnumerator OnDecrease()
    {
        var waitingTime = new WaitForSeconds(_coroutineDelay);

        yield return new WaitForSeconds(_waitBeforeResize);

        while(transform.localScale != Vector3.zero)
        {

            ChangeScale(_targetsSize[_currentIndex]);

            if (transform.localScale == _targetsSize[_currentIndex])
                _currentIndex++;

            yield return waitingTime;
        }

        gameObject.SetActive(false);
    }
}
