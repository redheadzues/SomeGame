using UnityEngine;

public class SpawnerDeathParticle : ObjectsPool
{
    [SerializeField] private GameObject _template;


    private void Start()
    {
        InitializePool(_template);
    }

    public void SetParticle(Vector3 position)
    {
        ParticleSystem particle = GetParticle();
        particle.transform.position = position;
    }

    private ParticleSystem GetParticle()
    {
        if(TryGetObject(out GameObject exemplar))
        {
            if(exemplar.TryGetComponent(out ParticleSystem particle))
            {
                exemplar.SetActive(true);
                return particle;
            }
        }

        return null;
    }
}
