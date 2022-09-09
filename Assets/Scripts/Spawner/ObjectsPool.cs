using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private float _capacity;
    [SerializeField] private Transform _container;

    private List<StickmanAnimator> _pool = new List<StickmanAnimator> ();

    protected void InitializePool(StickmanAnimator prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawned = Instantiate(prefab, _container);
            _pool.Add(spawned);
            spawned.gameObject.SetActive(false);
        }
    }

    protected bool TryGetObject(out StickmanAnimator exemplar)
    {
        exemplar = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return exemplar != null;
    }
}
