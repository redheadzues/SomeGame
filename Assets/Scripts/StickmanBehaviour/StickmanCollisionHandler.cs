using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StickmanFlightOperator))]
public class StickmanCollisionHandler : MonoBehaviour
{
    private StickmanFlightOperator _operator;

    private void Start()
    {
        _operator = GetComponent<StickmanFlightOperator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.TryGetComponent<StickmanPathFollower>(out StickmanPathFollower follower))
        {
            gameObject.SetActive(false);
            follower.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Wall>(out Wall wall))
        {
            var normal = collision.contacts[0].normal;
            var reflect = Vector3.Reflect(_operator.Direction, normal);
            _operator.StartFlying(reflect);
        }
    }
}
