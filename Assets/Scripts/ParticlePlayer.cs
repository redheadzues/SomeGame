using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlePlayer : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _particle.Stop();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _particle.Play();
        StartCoroutine(TryDeactive());
    }

    private IEnumerator TryDeactive()
    {
        while(_particle.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
