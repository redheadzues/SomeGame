using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastleBreaker : MonoBehaviour
{
    [SerializeField] private List<CastlePartBreaker> _parts;
    [SerializeField] private SpawnerExplosion _explosion;

    private int _currentPartIndex;

    public event Action<float, float> PartBreacked;
    public event Action CastleBreacked;

    private void OnValidate()
    {
        _explosion = FindObjectOfType<SpawnerExplosion>();
    }

    protected void Destroy()
    {
        _parts[_currentPartIndex].Activate();

        if(_explosion != null)
            _explosion.SetParticle(_parts[_currentPartIndex].transform.position);

        _currentPartIndex++;

        PartBreacked?.Invoke(_parts.Count - _currentPartIndex, _parts.Count);

        TryCompleteLevel();
    }

    private void TryCompleteLevel()
    {
        if (_currentPartIndex == _parts.Count)
            CastleBreacked?.Invoke();
    }
}
