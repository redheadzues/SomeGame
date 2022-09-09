using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLifter : MonoBehaviour
{
    [SerializeField] private float _timeToHoldOnPosition;
    [SerializeField] private float _coroutineDelay;
    [SerializeField] private float _positionVerticalMax;
    [SerializeField] private float _positionVerticalStayClosed;
    [SerializeField] private float _positionVerticalStayOpened;
    [SerializeField] private float _speed;

    private Vector3 _target;
    private List<float> _targets;
    private int _currentTargetIndex;
    private int _aviodLimitException = 1;

    private void Awake()
    {
        _targets = new List<float>();
        InitializeTargetsList();
    }

    private void Start()
    {
        _target = transform.position;
        StartCoroutine(OnMove());
    }

    private void InitializeTargetsList()
    {
        _targets.Add(_positionVerticalStayClosed);
        _targets.Add(_positionVerticalMax);
        _targets.Add(_positionVerticalStayOpened);
    }

    private void MoveToTargetPosition()
    {
        transform.position = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
    }

    private void ChangeCurrentTargetIndex()
    {
        if (_currentTargetIndex == (_targets.Count - _aviodLimitException))
            _currentTargetIndex = 0;
        else
            _currentTargetIndex++;
    }

    private void ChangeTarget()
    {
        _target = new Vector3(transform.position.x, _targets[_currentTargetIndex], transform.position.z);
    }

    private IEnumerator OnMove()
    {
        var holdPositionTime = new WaitForSeconds(_timeToHoldOnPosition);
        var delay = new WaitForSeconds(_coroutineDelay);

        while(true)
        {
            MoveToTargetPosition();
            yield return delay;

            if(transform.position == _target)
            {
                ChangeCurrentTargetIndex();
                ChangeTarget();
            }
        }
    }
}
