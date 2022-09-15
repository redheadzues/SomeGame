using UnityEngine;

public class SpawnerExplosion : ObjectsPool
{
    [SerializeField] private GameObject _particleExplosion;

    private void Start()
    {
        InitializePool(_particleExplosion);
    }

    public void SetParticle(Vector3 position)
    {
        ParticleSystem particle = GetParticle();
        particle.transform.position = position;
    }

    private ParticleSystem GetParticle()
    {
        if (TryGetObject(out GameObject exemplar))
        {
            if (exemplar.TryGetComponent(out ParticleSystem particle))
            {
                exemplar.SetActive(true);
                return particle;
            }
        }

        return null;
    }
}
