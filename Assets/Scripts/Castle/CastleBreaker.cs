using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastleBreaker : MonoBehaviour
{
    [SerializeField] private List<CastlePartBreaker> _parts;

    private int _currentPartIndex;

    public event Action<float, float> PartBreacked;

    protected void Destroy()
    {
        _parts[_currentPartIndex].Activate();
        _currentPartIndex++;

        PartBreacked?.Invoke(_parts.Count - _currentPartIndex, _parts.Count);
    }
}
