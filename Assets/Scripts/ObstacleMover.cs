using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float _minPointX;
    [SerializeField] private float _maxPointX;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        StartCoroutine(OnMove());
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void SetTargetPoint()
    {

        if(transform.position.x == _minPointX)
            _target =  new Vector3(_maxPointX, transform.position.y, transform.position.z);
        else
            _target =  new Vector3(_minPointX, transform.position.y, transform.position.z);
    }

    private IEnumerator OnMove()
    {
        SetTargetPoint();

        while(true)
        {
            Move(_target);

            if(transform.position == _target)
                SetTargetPoint();

            yield return new WaitForSeconds(0.01f);
        }
    }
}
