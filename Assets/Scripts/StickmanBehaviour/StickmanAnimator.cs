using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StickmanAnimator : MonoBehaviour
{
    private Animator _animator;
    private int _run = Animator.StringToHash("Run");
    private int _idle = Animator.StringToHash("Idle");

    private void Start()
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
}
