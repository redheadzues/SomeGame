using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private float _capacity;
    [SerializeField] private Transform _container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void InitializePool(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawned = Instantiate(prefab, _container);
            _pool.Add(spawned);
            spawned.SetActive(false);
        }
    }

    protected bool TryGetObject(out GameObject exemplar)
    {
        exemplar = _pool.FirstOrDefault(p => p.activeSelf == false);

        return exemplar != null;
    }
}
