using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationSwitcher : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animation)
    {
        _animator.StopPlayback();
        _animator.Play(animation);
    }
}
