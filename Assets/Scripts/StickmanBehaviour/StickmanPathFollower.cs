using System.Collections;
using UnityEngine;

public class StickmanPathFollower : StickmanAnimator
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _coroutineDelay;

    private const int _nextIndex = 1;
    private const int _zero = 0;
    private const int _one = 1;
    private PathKeeper _pathKeeper;
    private Transform[] _wayPoints;
    private int _currentIndex;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_pathKeeper != null)
        {
            _currentIndex = _zero;
            DefineWay();
            transform.rotation = GetTargetRotation(_wayPoints[_zero].position);
            BeginCoroutine();
        }
    }

    public void InitializePathKeeper(PathKeeper keeper)
    {
        _pathKeeper = keeper;
    }
    private void DefineWay()
    {
        int currentWay = Random.Range(0, _pathKeeper.transform.childCount);

        _wayPoints = new Transform[_pathKeeper.transform.GetChild(currentWay).childCount];

        for (int i = 0; i < _pathKeeper.transform.GetChild(currentWay).childCount; i++)
        {
            _wayPoints[i] = _pathKeeper.transform.GetChild(currentWay).GetChild(i);
        }
    }

    private void BeginCoroutine()
    {
        if( _coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnMove());
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void RotateToNextPoint(Vector3 target)
    {
        var targetRotation = GetTargetRotation(target);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        if(transform.rotation == targetRotation)
            IncreaseCurrentIndex();
    }

    private Quaternion GetTargetRotation(Vector3 target)
    {
        var direction = target - transform.position;

        return Quaternion.LookRotation(direction);
    }

    private void IncreaseCurrentIndex()
    {
        _currentIndex++;
    }

    private void TryDeactivate()
    {
        if (_currentIndex == _wayPoints.Length - _one)
        {
            StopCoroutine(OnMove());

        }
    }

    private IEnumerator OnMove()
    {
        var waitingTime = new WaitForSeconds(_coroutineDelay);

        while (transform.position != _wayPoints[_wayPoints.Length - _one].position)
        {
            Move(_wayPoints[_currentIndex].position);

            if(transform.position == _wayPoints[_currentIndex].position)
            {
                TryDeactivate();
                RotateToNextPoint(_wayPoints[_currentIndex + _nextIndex].position);
            }

            yield return waitingTime;
        }
    }
}
