using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBreaker : MonoBehaviour
{
    [SerializeField] private List<CastlePartBreaker> _parts;

    private int _currentPartIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<StickmanFlightOperator>(out StickmanFlightOperator flyOperator))
        {
            _parts[_currentPartIndex].Activate();
            _currentPartIndex++;
        }
    }
}
