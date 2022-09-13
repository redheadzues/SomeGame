using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StickmanAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string _run = "Run";
    private const string _idle = "Idle";
    private const string _fly = "Fly";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected void PlayRun()
    {
        _animator.Play(_run);
    }

    protected void PlayIdle()
    {
        _animator.Play(_idle);
    }

    protected void PlayFly()
    {
        _animator.Play(_fly);
    }
}
